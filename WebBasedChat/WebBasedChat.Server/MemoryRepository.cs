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

        static int roomId = 0;

        public int Create(string roomName)
        {
            lock (this)
            {
                _rooms.Add(roomId, roomName);
            }
            
            return roomId++;
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