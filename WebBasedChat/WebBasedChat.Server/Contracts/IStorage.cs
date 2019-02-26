using System;
using System.Collections.Generic;

namespace WebBasedChat.Server.Contracts
{
    public interface IStorage
    {
        void Add(string message, int userId);

        /// <summary>
        /// Get last message
        /// </summary>
        /// <param name="userId">id of requestor</param>
        /// <param name="idxOffset">offset from last message</param>
        /// <returns>message row</returns>
        List<Tuple<string, int, DateTime>> Last(int userId, int idxOffset);
    }
}