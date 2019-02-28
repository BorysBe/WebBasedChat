﻿using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using WebBasedChat.Communication.Contracts;
using IChatService = WebBasedChat.Communication.Contracts.IChatService;

namespace WebBasedChat.Communication
{
    public class ClientServiceProxy : IClientServiceProxy
    {
        private readonly IChatService _proxy;
        private int _userId;

        public ClientServiceProxy(string server)
        {
            var factory = new ChannelFactory<IChatService>(new WebHttpBinding(), server);
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            _proxy = factory.CreateChannel();
        }

        public void Send(string message)
        {
            this._proxy.Send(new Message() { Content = message, UserId = _userId });
        }

        public IEnumerable<StoredMessage> Last(int idxOffset = 0)
        {
            return _proxy.GetMessages(_userId, idxOffset).ToList();
        }

        public int CreateRoom(string roomName)
        {
            return _proxy.CreateRoom(roomName);
        }

        public IEnumerable<KeyValuePair<int, string>> GetRooms()
        {
            return _proxy.GetRooms();
        }

        public int RegisterUser(string userName)
        {
            _userId = _proxy.RegisterUser(userName);
            return _userId;
        }
    }

}