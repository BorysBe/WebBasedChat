using System;
using System.Collections.Generic;

namespace WebBasedChat.Server
{
    public class ChatService : IChatService
    {
        private readonly IStorage _storage = new MemoryStorage();

        public IEnumerable<Tuple<string, int, DateTime>> GetMessages(int userId)
        {
            return _storage.Last(userId, 30);
        }
    }
}
