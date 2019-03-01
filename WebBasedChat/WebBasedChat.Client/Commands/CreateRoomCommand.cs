using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class CreateRoomCommand : ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private readonly State _state;

        public CreateRoomCommand(IClientServiceProxy clientServiceProxy, State state)
        {
            _clientServiceProxy = clientServiceProxy;
            _state = state;
        }

        public void Execute()
        {
            var roomName = "Room " + _state.Rooms.Count;
            var roomId = _clientServiceProxy.CreateRoom(roomName);
            if (!_state.Rooms.ContainsKey(roomId))
            {
                _state.Rooms.Add(roomId, roomName);
            }
        }
    }
}