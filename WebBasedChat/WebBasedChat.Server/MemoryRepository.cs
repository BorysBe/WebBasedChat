using System;
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
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim(); // probably more readers then writers

        private static readonly Dictionary<int, string> Rooms = new Dictionary<int, string>();
        private static readonly Dictionary<int, string> Users = new Dictionary<int, string>();

        public void Create(string message, int userId)
        {
            locker.EnterWriteLock();
            try
            {
                _list.Add(new StoredMessage () { Content = message, UserId = userId, DateTime = DateTime.UtcNow } );
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        private object _userLock = new object ();
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

        public List<StoredMessage> Retrieve(int userId, int idxOffset)
        {
            StoredMessage result;
            locker.EnterReadLock();
            var results = new List<StoredMessage>();
            try
            {
                if (idxOffset == 0)
                {
                    result = _list.LastOrDefault(x => x.UserId != userId);
                    results.Add(result);
                }
                else
                {
                    for (int idx = idxOffset; idx > 0; idx--)
                    {
                        result = _list.ElementAt(_list.Count - idx);
                        results.Add(result);
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