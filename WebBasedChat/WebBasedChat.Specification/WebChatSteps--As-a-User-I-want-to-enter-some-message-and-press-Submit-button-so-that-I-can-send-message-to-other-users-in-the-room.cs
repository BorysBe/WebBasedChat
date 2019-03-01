using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Facades;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User enter ""(.*)"" message")]
        [When(@"User enter ""(.*)"" message")]
        public void UserEnterMessage(string message)
        {
            var application = (CommunicationFacade) ScenarioContext.Current["application1"];
            application.Enter(message);
        }

        [Given(@"User (.*) submit messages")]
        public void UserSubmitMessages(int userId, Table table)
        {
            var application = (CommunicationFacade) ScenarioContext.Current["application" + userId];
            foreach (var row in table.Rows)
            {
                application.Enter(row["message"]);
                application.Submit();
            }
        }

        [Then(@"""(.*)"" was send to user (.*)")]
        public void ThenWasSendTo(string message, int userId)
        {
            var state = (State)ScenarioContext.Current["state" + userId];
            var clientServiceProxy = (IClientServiceProxy)ScenarioContext.Current["clientServiceProxy" + userId];
            var content = clientServiceProxy.Last((int)state.JoinedChatRoom).ElementAt(0).Content;
            Assert.AreEqual(message, content);
        }
    }
}