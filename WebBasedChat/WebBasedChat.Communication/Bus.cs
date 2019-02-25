namespace WebBasedChat.Communication
{
    public class Bus : IBus
    {
        public void Send(string message)
        {
        }

        public string Last()
        {
            return string.Empty;
        }
    }
}