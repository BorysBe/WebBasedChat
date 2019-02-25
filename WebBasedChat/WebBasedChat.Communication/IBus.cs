using System;

namespace WebBasedChat.Communication
{
    public interface IBus
    {
        void Send(string message);
        Tuple<string, int, DateTime> Last(int idxOffset = 0);
    }
}