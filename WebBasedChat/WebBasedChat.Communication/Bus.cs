using System;

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

        public Tuple<string, int, DateTime> Last(int idxOffset = 0)
        {
            return this._storage.Last(_userId, idxOffset);
        }
    }
}