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
            var application = new Application(new State());
            ScenarioContext.Current["application"] = application;
        }
        
        [When(@"User see first screen")]
        public void WhenUserSeeFirstScreen()
        {
            var app = (Application)ScenarioContext.Current["application"];
            app.Show();
        }
        
        [Then(@"Should see Screen (.*)")]
        public void ThenShouldSeeScreen(int p0)
        {
            var app = (Application)ScenarioContext.Current["application"];
            var screenNumber = app.State.Screen;
            Assert.AreEqual(p0, screenNumber, "Invalid screen shown");
        }

        [AfterScenario]
        public void TearDown()
        {
            var application = (Application)ScenarioContext.Current["application"];
            application.Dispose();
        }
    }
}
