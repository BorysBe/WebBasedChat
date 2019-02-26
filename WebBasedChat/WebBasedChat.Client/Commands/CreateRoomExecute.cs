using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;

namespace WebBasedChat.Client.Commands
{
    public class CreateRoomExecute : ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private readonly State _state;

        public CreateRoomExecute(IClientServiceProxy clientServiceProxy, State state)
        {
            _clientServiceProxy = clientServiceProxy;
            _state = state;
        }

        private static int roomIdx;

        public void Execute()
        {
            var roomId = _clientServiceProxy.CreateRoom("room" + roomIdx++);
            _state.RoomsAreReady = true;
            _state.SelectedChatRoom = roomId;
        }
    }
}