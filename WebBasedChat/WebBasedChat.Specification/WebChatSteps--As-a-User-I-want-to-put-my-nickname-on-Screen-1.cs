using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User put a nickname '(.*)'")]
        public void GivenUserPutANickname(string nick)
        {
            var state = (State)ScenarioContext.Current["state1"];
            state.Name = nick;
        }

        [When(@"User put a nickname '(.*)'")]
        public void WhenUserPutANickname(string nick)
        {
            var state = (State) ScenarioContext.Current["state1"];
            state.Name = nick;
        }

        [Given(@"User '(.*)' put a nickname '(.*)'")]
        public void GivenOtherUserPutANickname(int userId, string nick)
        { 
            var state = (State) ScenarioContext.Current["state" + userId];
            state.Name = nick;
        }

        [Then(@"Nickname '(.*)' should be stored in application")]
        public void ThenNicknameShouldBeStored(string nick)
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.AreEqual(state.Name, nick);
        }

        [Given(@"User see Screen (.*)")]
        public void GivenUserSeeScreen(int screenNo)
        {
            var state = (State) ScenarioContext.Current["state1"];
            state.Screen = screenNo;
            var app = (CommunicationFacade) ScenarioContext.Current["application1"];
            app.Show();
        }

        [Then(@"User see Screen (.*)")]
        public void ThenUserSeeScreen(int screenNo)
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.AreEqual(screenNo, state.Screen, $"User cannot see {screenNo}");
        }
    }
}