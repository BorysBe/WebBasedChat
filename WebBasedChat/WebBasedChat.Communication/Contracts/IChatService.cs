using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebBasedChat.Communication.Contracts
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract, WebGet]
        IEnumerable<StoredMessage> GetMessages(int userId, int idxOffset);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Send",
            RequestFormat = WebMessageFormat.Json)]
        void Send(Message message);

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "CreateRoom",
            RequestFormat = WebMessageFormat.Json)]
        int CreateRoom(string roomName);
    }
}