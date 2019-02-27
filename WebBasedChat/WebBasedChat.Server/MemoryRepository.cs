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

        private static readonly Dictionary<int, string> _rooms = new Dictionary<int, string>();
        private static readonly Dictionary<int, string> _users = new Dictionary<int, string>();

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
                _rooms.Add(_roomId, roomName);
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
                _users.Add(_userId, userName);
            }

            return _userId++;
        }

        public IEnumerable<KeyValuePair<int, string>> Retrieve()
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