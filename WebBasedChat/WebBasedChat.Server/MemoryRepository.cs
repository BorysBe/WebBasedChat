﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebBasedChat.Communication;
using WebBasedChat.Server.Contracts;

namespace WebBasedChat.Server
{
    public class MemoryRepository : IRepository
    {
        private static readonly List<StoredMessage> _list = new List<StoredMessage>();
        private static readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim(); // probably more readers then writers

        private static readonly Dictionary<int, string> Rooms = new Dictionary<int, string>();
        private static readonly Dictionary<int, string> Users = new Dictionary<int, string>();

        public void Create(string message, int userId, int roomId)
        {
            string mappedUserName = string.Empty;
            mappedUserName = GetUserName(userId, mappedUserName);

            string mappedRoomName = string.Empty;
            mappedRoomName = GetRoomName(roomId, mappedRoomName);

            locker.EnterWriteLock();
            try
            {
                _list.Add(new StoredMessage()
                {
                    Content = message,
                    UserId = userId,
                    UserName = mappedUserName,
                    DateTime = DateTime.UtcNow,
                    RoomId = roomId,
                    RoomName = mappedRoomName
                });
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        private string GetRoomName(int roomId, string mappedRoomName)
        {
            lock (_roomLock)
            {
                if (Rooms.ContainsKey(roomId))
                {
                    mappedRoomName = Rooms[roomId];
                }
            }

            return mappedRoomName;
        }

        private string GetUserName(int userId, string mappedUserName)
        {
            lock (_userLock)
            {
                if (Users.ContainsKey(userId))
                {
                    mappedUserName = Users[userId];
                }
            }

            return mappedUserName;
        }

        private object _userLock = new object();
        private object _roomLock = new object();

        public int CreateRoom(string roomName)
        {
            var roomId = roomName.GetHashCode();
            lock (_roomLock)
            {
                if (Rooms.ContainsKey(roomId))
                {
                    return roomId;
                }

                Rooms.Add(roomId, roomName);
            }

            return roomId;
        }

        public int CreateUser(string userName)
        {
            var userId = userName.GetHashCode();
            lock (_userLock)
            {
                if (Users.ContainsKey(userId))
                {
                    return userId;
                }

                Users.Add(userId, userName);
            }

            return userId;
        }

        public IEnumerable<KeyValuePair<int, string>> Retrieve()
        {
            lock (this)
            {
                var pairs = Rooms.AsEnumerable();
                return pairs;
            }
        }

        public List<StoredMessage> Retrieve(int userId, int idxOffset, int roomId)
        {
            locker.EnterReadLock();
            var results = new List<StoredMessage>();
            try
            {
                StoredMessage result;
                if (idxOffset == 0)
                {
                    result = _list.LastOrDefault(x => x.UserId != userId && x.RoomId == roomId);
                    if (result != null)
                    {
                        results.Add(result);
                    }
                }
                else
                {
                    var storedMessages = _list
                        .Where(x => x.RoomId == roomId)
                        .Skip(_list.Count - idxOffset)
                        .ToList();

                    var count = storedMessages.Count();
                    if (count > 0)
                    {
                        if (count <= idxOffset)
                        {
                            results.AddRange(storedMessages);
                            return results;
                        }

                        for (int idx = idxOffset; idx > 0; idx--)
                        {
                            result = storedMessages.ElementAt(idx);
                            if (result != null)
                            {
                                results.Add(result);
                            }
                        }
                    }
                }
            }
            finally
            {
                locker.ExitReadLock();
            }

            return results;
        }
    }
}