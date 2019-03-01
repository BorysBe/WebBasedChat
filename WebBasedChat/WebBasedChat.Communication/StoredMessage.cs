using System;
using System.Runtime.Serialization;

namespace WebBasedChat.Communication
{
    [DataContract]
    public class StoredMessage : Message
    {
        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public object RoomName { get; set; }
    }
}