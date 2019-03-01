using System.Linq;
using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Client.Commands
{
    public class JoinSelectedRoomCommand : ICommand
    {
        private readonly State _state;

        public JoinSelectedRoomCommand(State state)
        {
            _state = state;
        }

        public void Execute()
        {
            var joinedChatRoom = _state.Rooms.ElementAt(_state.SelectedChatRoom ?? 0);
            _state.JoinedChatRoom = joinedChatRoom.Key;
            _state.Screen = 3;
        }
    }
}