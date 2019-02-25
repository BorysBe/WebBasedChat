using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;

namespace WebBasedChat.Specification
{
    [Binding]
    public class WebChatSteps
    {
        [Given(@"User run application")]
        public void GivenUserRunApplication()
        {
            CompositionRoot();
        }

        [Given(@"User (.*) run application")]
        public void GivenOtherUserRunApplication(int userId)
        {
            CompositionRoot(userId);
        }

        private static void CompositionRoot(int? userId = null)
        {
            var state = new State()
            {
                Screen = 1
            };
            ScenarioContext.Current["state" + userId] = state;
            var bus = new Bus(new MemoryStorage(), userId ?? 1);
            ScenarioContext.Current["bus" + userId] = bus;
            var application = new Application(
                state,
                bus);
            ScenarioContext.Current["application" + userId] = application;
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

        public void TearDown(int userId)
        {
            var application = (Application)ScenarioContext.Current["application" + userId];
            application.Dispose();
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

        [Given(@"User '(.*)' put a nickname '(.*)'")]
        public void GivenOtherUserPutANickname(int userId, string nick)
        {
            var state = (State)ScenarioContext.Current["state" + userId];
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

        [Given(@"User click ""(.*)"" button")]
        [When(@"User click ""(.*)"" button")]
        public void WhenUserClickButton(string buttonName)
        {
            var app = (Application)ScenarioContext.Current["application"];
            app.ExecuteOn(buttonName);
        }

        [Given(@"User '(.*)' click '(.*)' button")]
        public void GivenOtherUserClickButton(int userId, string buttonName)
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

        [Given(@"User (.*) join chat room (.*)")]
        public void GivenJoinChatRoom(int userId, int chatRoomId)
        {
            GivenOtherUserRunApplication(userId);
            GivenOtherUserPutANickname(userId, "User" + userId);
            GivenOtherUserClickButton(userId, "Join");
        }

        [When(@"User enter ""(.*)"" message")]
        public void WhenUserEnterMessage(string message)
        {
            var application = (Application)ScenarioContext.Current["application"];
            application.Enter(message);
        }

        [Then(@"""(.*)"" was send to user (.*)")]
        public void ThenWasSendTo(string message, int userId)
        {
            var bus = (IBus)ScenarioContext.Current["bus" + userId];
            Assert.AreEqual(message, bus.Last());
            TearDown(userId);
        }
    }
}
