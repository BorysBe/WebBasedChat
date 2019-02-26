using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebBasedChat.Server.Contracts
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract, WebGet]
        IEnumerable<Tuple<string, int, DateTime>> GetMessages(int userId, int idxOffset);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Send",
            RequestFormat = WebMessageFormat.Json)]
        void Send(Message message);

        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "CreateRoom",
            RequestFormat = WebMessageFormat.Json)]
        int CreateRoom(string roomName);
    }

    [DataContract]
    public class Message
    {
        [DataMember] public string Content { get; set; }

        [DataMember] public int UserId { get; set; }
    }
}