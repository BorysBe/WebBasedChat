using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User click ""(.*)"" button")]
        [When(@"User click ""(.*)"" button")]
        public void WhenUserClickButton(string buttonName)
        {
            var app = (Application) ScenarioContext.Current["application1"];
            app.CommandFactory.CreateFrom(buttonName).Execute();
        }

        [Given(@"User '(.*)' click '(.*)' button")]
        public void GivenOtherUserClickButton(int userId, string buttonName)
        {
            var app = (Application) ScenarioContext.Current["application1"];
            app.CommandFactory.CreateFrom(buttonName).Execute();
        }

        [Then(@"Chat room is created")]
        public void ThenChatRoomIsCreated()
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.IsTrue(state.RoomsAreReady, "Chat rooms are not ready");
        }
    }
}