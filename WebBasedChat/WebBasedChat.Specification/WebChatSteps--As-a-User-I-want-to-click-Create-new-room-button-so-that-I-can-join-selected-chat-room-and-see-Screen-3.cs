using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Facades;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Given(@"User (.*) load rooms")]
        public void GivenUserLoadRooms(int userId)
        {
            var app = (CommunicationFacade)ScenarioContext.Current["application" + userId];

            app.LoadRooms();
        }

        [Given(@"User select chat room (.*)")]
        public void GivenUserSelectChatRoom(int roomNo)
        {
            var app = (CommunicationFacade)ScenarioContext.Current["application" + 1];
            var state = (State) ScenarioContext.Current["state1"];
            state.SelectedChatRoom = 0;
            app.Join();
            app.Proceed();
        }

        [Given(@"User (.*) select chat room (.*)")]
        public void GivenOtherUserSelectChatRoom(int userId, int roomNo)
        {
            var state = (State)ScenarioContext.Current["state" + userId];
            state.SelectedChatRoom = roomNo;
        }

        [Then(@"User join selected chat room")]
        public void ThenUserJoinSelectedChatRoom()
        {
            var state = (State) ScenarioContext.Current["state1"];
            Assert.AreEqual(state.Rooms.ElementAt((int)state.SelectedChatRoom).Key, state.JoinedChatRoom, "Did not join selected chat room");
        }

        [Given(@"User (.*) join chat room (.*)")]
        public void GivenJoinChatRoom(int userId, int chatRoomId)
        {
            GivenOtherUserRunApplication(userId);
            GivenOtherUserPutANickname(userId, $"User{userId}");
            GivenOtherUserClickButton(userId,"Proceed");
            GivenUserLoadRooms(userId);
            GivenOtherUserPutANickname(userId, "User" + userId);
            GivenOtherUserSelectChatRoom(userId, chatRoomId);
            GivenOtherUserClickButton(userId, "Join");
        }
    }
}