using System.Collections.Generic;
using System.ServiceModel;
using WebBasedChat.Communication;
using WebBasedChat.Communication.Contracts;
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
            return _repository.CreateRoom(roomName);
        }

        public IEnumerable<KeyValuePair<string, int>> GetRooms()
        {
            return _repository.Retrieve();
        }

        public int RegisterUser(string userName)
        {
            return _repository.CreateUser(userName);
        }
    }
}
