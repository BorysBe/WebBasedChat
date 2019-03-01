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

        public IEnumerable<StoredMessage> GetMessages(int userId, int idxOffset, int roomId)
        {
            return _repository.Retrieve(userId, idxOffset, roomId);
        }

        public void Send(Message message)
        {
            _repository.Create(message.Content, message.UserId, message.RoomId);
        }

        public int CreateRoom(string roomName)
        {
            return _repository.CreateRoom(roomName);
        }

        public IEnumerable<KeyValuePair<int, string>> GetRooms()
        {
            return _repository.Retrieve();
        }

        public int RegisterUser(string userName)
        {
            return _repository.CreateUser(userName);
        }
    }
}
