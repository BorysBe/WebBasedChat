using System;
using System.Runtime.Serialization;

namespace WebBasedChat.Communication
{
    [DataContract]
    public class StoredMessage : Message
    {
        [DataMember]
        public DateTime DateTime { get; set; }
    }
}