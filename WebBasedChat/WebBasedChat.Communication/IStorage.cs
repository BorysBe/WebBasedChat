namespace WebBasedChat.Communication
{
    public interface IStorage
    {
        void Add(string message, int userId);

        /// <summary>
        /// Get last message
        /// </summary>
        /// <param name="userId">id of requestor</param>
        /// <param name="idxOffset">offset from last message</param>
        /// <returns></returns>
        string Last(int userId, int idxOffset);
    }
}