using System;
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
            ScenarioContext.Current["application"] = new Application();
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User see first screen")]
        public void WhenUserSeeFirstScreen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Should see Screen (.*)")]
        public void ThenShouldSeeScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [AfterScenario]
        public void TearDown()
        {
            var application = (Application)ScenarioContext.Current["application"];
            application.Dispose();
        }
    }
}
