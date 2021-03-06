﻿using TechTalk.SpecFlow;
using WebBasedChat.Client.Facades;
using WebBasedChat.Client.Factories;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;
using WebBasedChat.Server;

namespace WebBasedChat.Specification
{
    [Binding]
    public partial class WebChatSteps
    {
        private static Server.Server _server;

        [Given(@"User run application")]
        public void GivenUserRunApplication()
        {
            CompositionRoot(1);
        }

        [Given(@"User (.*) run application")]
        public void GivenOtherUserRunApplication(int userId)
        {
            CompositionRoot(userId);
        }

        private static void CompositionRoot(int userId = 1)
        {
            var state = new State()
            {
                Screen = 1
            };
            if (_server == null)
            {
                _server = new Server.Server(new MemoryRepository());
            }
            ScenarioContext.Current["state" + userId] = state;
            var clientServiceProxy = new ClientServiceProxy(_server.Address.OriginalString);
            ScenarioContext.Current["clientServiceProxy" + userId] = clientServiceProxy;
            var commandFactory = new CommandFactory(state, clientServiceProxy);
            ScenarioContext.Current["commandFactory" + userId] = commandFactory;
            var application = new CommunicationFacade(state, commandFactory);
            ScenarioContext.Current["application" + userId] = application;
        }
    }
}
