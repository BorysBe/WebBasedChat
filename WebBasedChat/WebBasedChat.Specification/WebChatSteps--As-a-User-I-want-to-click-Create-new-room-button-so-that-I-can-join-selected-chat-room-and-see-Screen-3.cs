using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User select chat room (.*)")]
        public void GivenUserSelectChatRoom(int roomNo)
        {
            var state = (State) ScenarioContext.Current["state1"];
            state.SelectedChatRoom = roomNo;
        }

        [Then(@"User join selected chat room")]
        public void ThenUserJoinSelectedChatRoom()
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.AreEqual(state.SelectedChatRoom, state.JoinedChatRoom, "Did not join selected chat room");
        }

        [Given(@"User (.*) join chat room (.*)")]
        public void GivenJoinChatRoom(int userId, int chatRoomId)
        {
            GivenOtherUserRunApplication(userId);
            GivenOtherUserPutANickname(userId, "User" + userId);
            GivenOtherUserClickButton(userId, "Join");
        }
    }
}