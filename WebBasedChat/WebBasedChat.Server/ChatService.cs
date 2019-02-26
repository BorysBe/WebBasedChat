using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebBasedChat.Server.Contracts;

namespace WebBasedChat.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        public ChatService(IStorage storage)
        {
            _storage = storage;
        }

        private readonly IStorage _storage;

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
