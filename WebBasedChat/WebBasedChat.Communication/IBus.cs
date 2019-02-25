namespace WebBasedChat.Communication
{
    public interface IBus
    {
        void Send(string message);
        string Last();
    }
}