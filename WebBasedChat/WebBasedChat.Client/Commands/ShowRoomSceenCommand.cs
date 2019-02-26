using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Client.Commands
{
    public class ShowRoomSceenCommand : ICommand
    {
        private readonly State _state;

        public ShowRoomSceenCommand(State state)
        {
            _state = state;
        }

        public void Execute()
        {
            _state.Screen = 2;
        }
    }
}