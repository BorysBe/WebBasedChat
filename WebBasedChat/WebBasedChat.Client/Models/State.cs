namespace WebBasedChat.Client.Models
{
    public class State
    {
        public int Screen { get; set; }
        public string Name { get; set; }
        public bool RoomsAreReady { get; set; }
        public int? SelectedChatRoom { get; set; }
        public int? JoinedChatRoom { get; set; }
    }
}