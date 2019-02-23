using NUnit.Framework;
using NUnit.Framework.Constraints;
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
            var application = new Application(new State());
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

    }
}
