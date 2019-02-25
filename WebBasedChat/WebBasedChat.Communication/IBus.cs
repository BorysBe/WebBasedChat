using System;
using System.Collections.Generic;

namespace WebBasedChat.Communication
{
    public interface IBus
    {
        void Send(string message);
        IEnumerable<Tuple<string, int, DateTime>> Last(int idxOffset = 0);
    }
}