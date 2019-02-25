using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WebBasedChat.Server
{
    public class MemoryStorage : IStorage
    {
        private static readonly List<Tuple<string, int, DateTime>> _list = new List<Tuple<string, int, DateTime>>();
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim(); // probably more readers then writers

        public void Add(string message, int userId)
        {
            locker.EnterWriteLock();
            try
            {
                _list.Add(new Tuple<string, int, DateTime>(message, userId, DateTime.UtcNow));
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        public List<Tuple<string, int, DateTime>> Last(int userId, int idxOffset)
        {
            Tuple<string, int, DateTime> result;
            locker.EnterReadLock();
            var results = new List<Tuple<string, int, DateTime>>();
            try
            {
                if (idxOffset == 0)
                {
                    result = _list.LastOrDefault(x => x.Item2 != userId);
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