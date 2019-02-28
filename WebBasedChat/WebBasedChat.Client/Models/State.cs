using System.Collections.Generic;
using System.Linq;

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
        public Dictionary<string, int> Rooms { get; set; } = new Dictionary<string, int>();
        public int UserId { get; set; }
    }
}