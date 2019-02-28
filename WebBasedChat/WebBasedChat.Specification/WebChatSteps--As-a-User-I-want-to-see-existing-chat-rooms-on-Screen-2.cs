using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Then(@"Should see existing chat rooms on Screen (.*)")]
        public void ThenShouldSeeExistingChatRoomsOnScreen(int screenNo)
        {
            var state = (State) ScenarioContext.Current["state1"];
            var screenNumber = state.Screen;
            Assert.AreEqual(screenNo, screenNumber, "Invalid screen shown");
            Assert.IsTrue(state.RoomsAreReady, "Chat rooms are not ready");
        }
    }
}