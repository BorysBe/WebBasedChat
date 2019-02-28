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

        //todo: create second rest service for rooms and users

        [OperationContract, WebGet]
        IEnumerable<KeyValuePair<int, string>> GetRooms();

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "RegisterUser",
            RequestFormat = WebMessageFormat.Json)]
        int RegisterUser(string userName);
    }
}