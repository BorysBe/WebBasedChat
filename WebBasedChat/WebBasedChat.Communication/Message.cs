using System.Runtime.Serialization;

namespace WebBasedChat.Communication
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int RoomId { get; set; }
    }
}