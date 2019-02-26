using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using WebBasedChat.Server;

namespace WebBasedChat.Communication
{
    public class Bus : IBus
    {
        private readonly string _server;
        private readonly int _userId;
        private IChatService _proxy;

        public Bus(string server, int userId)
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

        public IEnumerable<Tuple<string, int, DateTime>> Last(int idxOffset = 0)
        {
            return _proxy.GetMessages(_userId, idxOffset).ToList();
        }

    }

}