using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Factories.Contracts;
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
            var application = (Application) ScenarioContext.Current["application1"];
            application.Enter(message);
        }

        [Given(@"User (.*) submit messages")]
        public void UserSubmitMessages(int userId, Table table)
        {
            var application = (Application) ScenarioContext.Current["application" + userId];
            var commandFactory = (ICommandFactory)ScenarioContext.Current["commandFactory" + userId];

            foreach (var row in table.Rows)
            {
                application.Enter(row["message"]);
                commandFactory.CreateFrom("Submit").Execute();
            }
        }

        [Then(@"""(.*)"" was send to user (.*)")]
        public void ThenWasSendTo(string message, int userId)
        {
            var clientServiceProxy = (IClientServiceProxy)ScenarioContext.Current["clientServiceProxy" + userId];
            Assert.AreEqual(message, clientServiceProxy.Last().ElementAt(0).Content);
            TearDown(userId);
        }
    }
}