using System;
using System.Collections.Generic;
using System.ServiceModel;
using WebBasedChat.Server.Contracts;

namespace WebBasedChat.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        public ChatService(IRepository repository)
        {
            _repository = repository;
        }

        private readonly IRepository _repository;

        public IEnumerable<Tuple<string, int, DateTime>> GetMessages(int userId, int idxOffset)
        {
            return _repository.Retrieve(userId, idxOffset);
        }

        public void Send(Message message)
        {
            _repository.Create(message.Content, message.UserId);
        }

        public int CreateRoom(string roomName)
        {
            return _repository.Create(roomName);
        }
    }
}
