using System;
using System.Collections.Generic;
using WebBasedChat.Server;

namespace WebBasedChat.Communication
{
    public class Bus : IBus
    {
        private readonly IStorage _storage;
        private readonly int _userId;

        public Bus(IStorage storage, int userId)
        {
            _storage = storage;
            _userId = userId;
        }

        public void Send(string message)
        {
            this._storage.Add(message, _userId);
        }

        public IEnumerable<Tuple<string, int, DateTime>> Last(int idxOffset = 0)
        {
            return _storage.Last(_userId, idxOffset);
        }
    }
}