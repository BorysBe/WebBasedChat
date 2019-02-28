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

        private static readonly Dictionary<string, int> _rooms = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> _users = new Dictionary<string, int>();

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

        static int _roomId = 0;
        static int _userId = 0;

        private object _userLock;

        public int CreateRoom(string roomName)
        {
            if (_roomId == int.MaxValue)
            {
                return -1;
            }

            lock (this)
            {
                _rooms.Add(roomName, _roomId);
            }
            
            return _roomId++;
        }

        public int CreateUser(string userName)
        {
            if (_userId == int.MaxValue)
            {
                return -1;
            }

            _userLock = new object();
            lock (_userLock)
            {
                if (_users.ContainsKey(userName))
                {
                    return _users[userName];
                }

                _users.Add(userName, _userId);
            }

            return _userId++;
        }

        public IEnumerable<KeyValuePair<string, int>> Retrieve()
        {
            lock (this)
            {
                var pairs = _rooms.AsEnumerable();
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