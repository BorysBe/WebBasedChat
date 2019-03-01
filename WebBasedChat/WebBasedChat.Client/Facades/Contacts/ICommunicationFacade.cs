namespace WebBasedChat.Client.Facades.Contacts
{
    public interface ICommunicationFacade
    {
        void Enter(string message);
        void Submit();
        void Proceed();
        void LoadRooms();
        void CreateRoom();
        void LoadMessages();
        void Join();
    }
}