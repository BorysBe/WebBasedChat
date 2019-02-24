using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    [Binding]
    public class WebChatSteps
    {
        [Given(@"User run application")]
        public void GivenUserRunApplication()
        {
            var state = new State() { Screen = 1 };
            ScenarioContext.Current["state"] = state;
            var application = new Application(state);
            ScenarioContext.Current["application"] = application;
        }

        [Given(@"User see application window")]
        [When(@"User see application window")]
        public void WhenUserSeeApplicationWindow()
        {
            var app = (Application)ScenarioContext.Current["application"];
            app.Show();
        }

        [Then(@"Should see Screen (.*)")]
        public void ThenShouldSeeScreen(int expectedScreen)
        {
            var state = (State)ScenarioContext.Current["state"];
            var screenNumber = state.Screen;
            Assert.AreEqual(expectedScreen, screenNumber, "Invalid screen shown");
        }

        [AfterScenario]
        public void TearDown()
        {
            var application = (Application)ScenarioContext.Current["application"];
            application.Dispose();
        }

        [When(@"User put a nickname '(.*)'")]
        public void WhenUserPutANickname(string nick)
        {
            var state = (State)ScenarioContext.Current["state"];
            state.Name = nick;
        }

        [Then(@"Nickname '(.*)' should be stored")]
        public void ThenNicknameShouldBeStored(string nick)
        {
            var state = (State)ScenarioContext.Current["state"];
            Assert.AreEqual(state.Name, nick);
        }

        [When(@"User click proceed button")]
        public void WhenUserClickProceedButton()
        {
            var application = (Application)ScenarioContext.Current["application"];
            application.Proceed();
        }

        [Given(@"User see Screen (.*)")]
        public void GivenUserSeeScreen(int screenNo)
        {
            var state = (State)ScenarioContext.Current["state"];
            state.Screen = 2;
            var app = (Application)ScenarioContext.Current["application"];
            app.Show();
        }

        [Then(@"User see Screen (.*)")]
        public void ThenUserSeeScreen(int screenNo)
        {
            var state = (State)ScenarioContext.Current["state"];
            Assert.AreEqual(screenNo, state.Screen, $"User cannot see {screenNo}");
        }

        [Then(@"Should see existing chat rooms on Screen (.*)")]
        public void ThenShouldSeeExistingChatRoomsOnScreen(int screenNo)
        {
            var state = (State)ScenarioContext.Current["state"];
            var screenNumber = state.Screen;
            Assert.AreEqual(screenNo, screenNumber, "Invalid screen shown");
            Assert.IsTrue(state.RoomsAreReady, "Chat rooms are not ready");
        }

        [Given(@"At least one chat room exists")]
        public void GivenAtLeastOneChatRoomExists()
        {
            var state = (State)ScenarioContext.Current["state"];
            state.RoomsAreReady = true;
        }

        [When(@"User click ""(.*)"" button")]
        public void WhenUserClickButton(string buttonName)
        {
            var app = (Application)ScenarioContext.Current["application"];
            app.ExecuteOn(buttonName);
        }

        [Then(@"Chat room is created")]
        public void ThenChatRoomIsCreated()
        {
            var state = (State)ScenarioContext.Current["state"];
            Assert.IsTrue(state.RoomsAreReady, "Chat rooms are not ready");
        }

        [Given(@"User select chat room (.*)")]
        public void GivenUserSelectChatRoom(int roomNo)
        {
            var state = (State)ScenarioContext.Current["state"];
            state.SelectedChatRoom = roomNo;
        }

        [Then(@"User join selected chat room")]
        public void ThenUserJoinSelectedChatRoom()
        {
            var state = (State)ScenarioContext.Current["state"];
            Assert.AreEqual(state.SelectedChatRoom, state.JoinedChatRoom, "Did not join selected chat room");
        }

        [Given(@"User join selected chat room")]
        public void GivenUserJoinSelectedChatRoom()
        {
        }

        [Given(@"""(.*)"" join chat room (.*)")]
        public void GivenJoinChatRoom(string p0, int p1)
        {
        }

        [When(@"User enter ""(.*)"" message")]
        public void WhenUserEnterMessage(string message)
        {
        }

        [Then(@"""(.*)"" was send to ""(.*)""")]
        public void ThenWasSendTo(string message, string userName)
        {
            Assert.Fail("assertion empty");
        }
    }
}
