using System;
using System.Collections.Generic;

namespace WebBasedChat.Server
{
    public class ChatService : IChatService
    {
        private readonly IStorage _storage = new MemoryStorage();

        public IEnumerable<Tuple<string, int, DateTime>> GetMessages(int userId, int idxOffset)
        {
            return _storage.Last(userId, idxOffset);
        }

        public void Send(Message message)
        {
            _storage.Add(message.Content, message.UserId);
        }
    }
}
