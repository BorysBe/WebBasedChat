namespace WebBasedChat.Communication
{
    public interface IStorage
    {
        void Add(string message, int userId);
        string Last(int userId);
    }
}