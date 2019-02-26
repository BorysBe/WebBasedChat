using System;
using System.Collections.Generic;

namespace WebBasedChat.Server.Contracts
{
    public interface IRepository
    {
        /// <summary>
        /// Create an message entry
        /// </summary>
        /// <param name="message"></param>
        /// <param name="userId"></param>
        void Create(string message, int userId);

        /// <summary>
        /// Create new room
        /// </summary>
        /// <param name="roomName">room name</param>
        /// <returns>id of created room</returns>
        int Create(string roomName);

        /// <summary>
        /// Get last message
        /// </summary>
        /// <param name="userId">id of requestor</param>
        /// <param name="idxOffset">offset from last message</param>
        /// <returns>message row</returns>
        List<Tuple<string, int, DateTime>> Retrieve(int userId, int idxOffset);
    }
}