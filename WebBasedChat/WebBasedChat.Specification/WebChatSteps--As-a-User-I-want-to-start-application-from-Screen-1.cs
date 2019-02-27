using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User see application window")]
        [When(@"User see application window")]
        public void WhenUserSeeApplicationWindow()
        {
            var app = (Application) ScenarioContext.Current["application1"];
            app.Show();
        }

        [Then(@"Should see Screen (.*)")]
        public void ThenShouldSeeScreen(int expectedScreen)
        {
            var state = (State) ScenarioContext.Current["state1"];
            var screenNumber = state.Screen;
            Assert.AreEqual(expectedScreen, screenNumber, "Invalid screen shown");
        }

        public void TearDown(int userId)
        {
            var application = (Application) ScenarioContext.Current["application" + userId];
            application.Dispose();
        }

        [AfterScenario]
        public void TearDown()
        {
            var application = (Application) ScenarioContext.Current["application1"];
            application.Dispose();
            _server?.Dispose();
            _server = null;
        }
    }
}