using System.Collections.Generic;

namespace WebBasedChat.Communication.Contracts
{
    public interface IClientServiceProxy
    {
        void Send(string message);
        IEnumerable<StoredMessage> Last(int idxOffset = 0);
        int CreateRoom(string roomName);
        IEnumerable<KeyValuePair<int, string>> GetRooms();
        int RegisterUser(string userName);
    }
}