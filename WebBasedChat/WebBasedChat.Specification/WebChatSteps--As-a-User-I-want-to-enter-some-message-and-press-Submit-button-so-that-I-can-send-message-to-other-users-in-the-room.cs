using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
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
            foreach (var row in table.Rows)
            {
                application.Enter(row["message"]);
                application.CommandFactory.CreateFrom("Submit").Execute();
            }
        }

        [Then(@"""(.*)"" was send to user (.*)")]
        public void ThenWasSendTo(string message, int userId)
        {
            var bus = (IClientServiceProxy) ScenarioContext.Current["clientServiceProxy" + userId];
            Assert.AreEqual(message, bus.Last().ElementAt(0).Content);
            TearDown(userId);
        }
    }
}