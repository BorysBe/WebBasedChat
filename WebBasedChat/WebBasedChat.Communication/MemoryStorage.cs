using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace WebBasedChat.Communication
{
    public class MemoryStorage : IStorage
    {
        private static readonly List<Tuple<int, string>> _list = new List<Tuple<int, string>>();
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim(); // probably more readers then writers

        public void Add(string message, int userId)
        {
            locker.EnterWriteLock();
            try
            {
                _list.Add(new Tuple<int, string>(userId, message));
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }

        public string Last(int userId)
        {
            string result;
            locker.EnterReadLock();
            try
            {
                result = _list.LastOrDefault(x => x.Item1 != userId)?.Item2;
            }
            finally
            {
                locker.ExitReadLock();
            }

            return result;
        }
    }
}