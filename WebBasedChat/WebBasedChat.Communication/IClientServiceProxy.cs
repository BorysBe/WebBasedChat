using System;
using System.Collections.Generic;

namespace WebBasedChat.Communication
{
    public interface IClientServiceProxy
    {
        void Send(string message);
        IEnumerable<Tuple<string, int, DateTime>> Last(int idxOffset = 0);
        int CreateRoom(string roomName);
    }
}