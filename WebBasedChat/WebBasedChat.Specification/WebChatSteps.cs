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
            var application = new Application(new State() { Screen = 1 });
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
            var app = (Application)ScenarioContext.Current["application"];
            var screenNumber = app.State.Screen;
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
            var application = (Application)ScenarioContext.Current["application"];
            application.State.Name = nick;
        }

        [Then(@"Nickname '(.*)' should be stored")]
        public void ThenNicknameShouldBeStored(string nick)
        {
            var application = (Application)ScenarioContext.Current["application"];
            Assert.AreEqual(application.State.Name, nick);
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
            var app = (Application)ScenarioContext.Current["application"];
            app.State.Screen = 2;
            app.Show();
        }

        [Then(@"User see Screen (.*)")]
        public void ThenUserSeeScreen(int screenNo)
        {
            var app = (Application)ScenarioContext.Current["application"];
            Assert.AreEqual(screenNo, app.State.Screen, $"User cannot see {screenNo}");
        }

        [Then(@"Should see existing chat rooms on Screen (.*)")]
        public void ThenShouldSeeExistingChatRoomsOnScreen(int screenNo)
        {
            var app = (Application)ScenarioContext.Current["application"];
            var screenNumber = app.State.Screen;
            Assert.AreEqual(screenNo, screenNumber, "Invalid screen shown");
            Assert.IsTrue(app.State.RoomsAreReady, "Chat rooms are not ready");
        }

        [Given(@"At least one chat room exists")]
        public void GivenAtLeastOneChatRoomExists()
        {
            var app = (Application)ScenarioContext.Current["application"];
            app.State.RoomsAreReady = true;
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
            var app = (Application)ScenarioContext.Current["application"];
            Assert.IsTrue(app.State.RoomsAreReady, "Chat rooms are not ready");
        }

        [Given(@"User select chat room (.*)")]
        public void GivenUserSelectChatRoom(int roomNo)
        {
            var app = (Application) ScenarioContext.Current["application"];
            app.State.SelectedChatRoom = roomNo;
        }

        [Then(@"User join selected chat room")]
        public void ThenUserJoinSelectedChatRoom()
        {
            var app = (Application)ScenarioContext.Current["application"];
            Assert.AreEqual(app.State.SelectedChatRoom, app.State.JoinedChatRoom, "Did not join selected chat room");
        }

    }
}
