using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Client.Facades.Contacts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Then(@"Following messages was send to user (.*)")]
        public void ThenFollowingMessagesWasSendToUser(int userId, Table table)
        {
            var state = (State)ScenarioContext.Current["state" + userId];
            var facade = (ICommunicationFacade)ScenarioContext.Current["application" + userId];
            facade.LoadMessages();
            int rowNo = 0;
            if (table.Rows.Count > 0)
            {
                Assert.IsNotEmpty(state.Messages, $"There should be stored some messages for {userId}");
            }

            foreach (var row in table.Rows)
            {
                Assert.AreEqual(row["message"], state.Messages[rowNo].Content);
                Assert.AreEqual(row["nick"], state.Messages[rowNo].UserName);
                Assert.IsInstanceOf<DateTime>(state.Messages[rowNo].DateTime);
                rowNo++;
            }

            TearDown(userId);
        }

        private static string MapIdToNickname(Message tuple)
        {
            return $"User {tuple.UserId}";
        }
    }
}