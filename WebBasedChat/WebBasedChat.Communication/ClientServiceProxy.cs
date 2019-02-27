using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using WebBasedChat.Communication.Contracts;
using IChatService = WebBasedChat.Communication.Contracts.IChatService;

namespace WebBasedChat.Communication
{
    public class ClientServiceProxy : IClientServiceProxy
    {
        private readonly string _server;
        private readonly int _userId;
        private readonly IChatService _proxy;

        public ClientServiceProxy(string server, int userId)
        {
            _server = server;
            _userId = userId;
            var factory = new ChannelFactory<IChatService>(new WebHttpBinding(), _server);
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            _proxy = factory.CreateChannel();
        }

        public void Send(string message)
        {
            this._proxy.Send(new Message() { Content = message, UserId = _userId});
        }

        public IEnumerable<StoredMessage> Last(int idxOffset = 0)
        {
            return _proxy.GetMessages(_userId, idxOffset).ToList();
        }

        public int CreateRoom(string roomName)
        {
            return _proxy.CreateRoom(roomName);
        }
    }

}