using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebBasedChat.Communication;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Specification
{
    public partial class WebChatSteps
    {
        [Then(@"Following messages was send to user (.*)")]
        public void ThenFollowingMessagesWasSendToUser(int userId, Table table)
        {
            var bus = (IClientServiceProxy) ScenarioContext.Current["clientServiceProxy" + userId];
            int minusId = 30;
            var storedMessages = bus.Last(1, minusId);
            int rowNo = 0;
            foreach (var row in table.Rows)
            {
                Assert.AreEqual(row["message"], storedMessages.ElementAt(rowNo).Content);
                Assert.AreEqual(row["nick"], storedMessages.ElementAt(rowNo).UserName);
                Assert.IsInstanceOf<DateTime>(storedMessages.ElementAt(rowNo).DateTime);
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