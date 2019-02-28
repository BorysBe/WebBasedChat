using System.Collections.Generic;
using System.Linq;
using WebBasedChat.Communication;

namespace WebBasedChat.Client.Models
{
    public class State
    {
        public int Screen { get; set; }
        public string LastMessage { get; set; }
        public string Name { get; set; }
        public bool RoomsAreReady => Rooms.Any();
        public int? SelectedChatRoom { get; set; }
        public int? JoinedChatRoom { get; set; }
        public Dictionary<int, string> Rooms { get; set; } = new Dictionary<int, string>();
        public int UserId { get; set; }
        public List<StoredMessage> Messages { get; set; } = new List<StoredMessage>();
    }
}