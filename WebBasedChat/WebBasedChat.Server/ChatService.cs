using System.Collections.Generic;
using System.ServiceModel;
using WebBasedChat.Communication;
using WebBasedChat.Server.Contracts;
using Message = WebBasedChat.Server.Contracts.Message;

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

        public IEnumerable<StoredMessage> GetMessages(int userId, int idxOffset)
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
