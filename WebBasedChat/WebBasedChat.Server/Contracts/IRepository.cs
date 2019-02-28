using System.Collections.Generic;
using WebBasedChat.Communication;

namespace WebBasedChat.Server.Contracts
{
    public interface IRepository
    {
        /// <summary>
        /// Create an message entry
        /// </summary>
        /// <param name="message">message send to chat room</param>
        /// <param name="userId">id of user</param>
        void Create(string message, int userId);

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="roomName">room name</param>
        /// <returns>id of created room</returns>
        int CreateRoom(string roomName);

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="userName">room name</param>
        /// <returns>id of created room</returns>
        int CreateUser(string userName);

        /// <summary>
        /// Get last message
        /// </summary>
        /// <param name="userId">id of requestor</param>
        /// <param name="idxOffset">offset from last message</param>
        /// <returns>message row</returns>
        List<StoredMessage> Retrieve(int userId, int idxOffset);

        /// <summary>
        /// Retrieve rooms with its id's
        /// </summary>
        /// <returns>room list</returns>
        IEnumerable<KeyValuePair<string, int>> Retrieve();
    }
}