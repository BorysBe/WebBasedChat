using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebBasedChat.Server
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetMessages")]
        IEnumerable<Tuple<string, int, DateTime>> GetMessages(int userId);
    }
}
