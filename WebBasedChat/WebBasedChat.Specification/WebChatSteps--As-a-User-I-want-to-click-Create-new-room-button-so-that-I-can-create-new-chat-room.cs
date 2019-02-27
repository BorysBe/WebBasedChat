using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Factories.Contracts;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User click ""(.*)"" button")]
        [When(@"User click ""(.*)"" button")]
        public void WhenUserClickButton(string buttonName)
        {
            var commandFactory = (ICommandFactory)ScenarioContext.Current["commandFactory1"];
            commandFactory.CreateFrom(buttonName).Execute();
        }

        [Given(@"User '(.*)' click '(.*)' button")]
        public void GivenOtherUserClickButton(int userId, string buttonName)
        {
            var commandFactory = (ICommandFactory)ScenarioContext.Current["commandFactory" + userId];
            commandFactory.CreateFrom(buttonName).Execute();
        }

        [Then(@"Chat room is created")]
        public void ThenChatRoomIsCreated()
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.IsTrue(state.RoomsAreReady, "Chat rooms are not ready");
        }
    }
}