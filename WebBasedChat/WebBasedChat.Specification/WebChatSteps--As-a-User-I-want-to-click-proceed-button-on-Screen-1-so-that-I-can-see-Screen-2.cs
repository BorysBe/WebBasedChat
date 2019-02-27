using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [When(@"User click proceed button")]
        public void WhenUserClickProceedButton()
        {
            var application = (Application) ScenarioContext.Current["application1"];
            application.Proceed();
        }
    }
}