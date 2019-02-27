using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;
using WebBasedChat.Communication.Contracts;
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
            var bus = new ClientServiceProxy(_server.Address.OriginalString, userId);
            ScenarioContext.Current["clientServiceProxy" + userId] = bus;
            var application = new Application(
                state,
                bus);
            ScenarioContext.Current["application" + userId] = application;
            
        }
    }
}
