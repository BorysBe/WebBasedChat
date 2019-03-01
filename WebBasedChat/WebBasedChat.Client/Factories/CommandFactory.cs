using WebBasedChat.Client.Commands;
using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Factories.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly State _state;
        private readonly IClientServiceProxy _clientProxy;

        public CommandFactory(State state, IClientServiceProxy clientProxy)
        {
            _state = state;
            _clientProxy = clientProxy;
        }

        public ICommand CreateFrom(string buttonName)
        {
            if (buttonName == "Join")
            {
                return new JoinSelectedRoomCommand(_state);
            }

            if (buttonName == "Create new room")
            {
                return new CreateRoomCommand(_clientProxy, _state); ;
            }

            if (buttonName == "Submit")
            {
                return new SubmitCommand(_clientProxy, _state);
            }

            if (buttonName == "Back")
            {
                return new ProceedScreenCommand(_state);
            }

            if (buttonName == "Proceed")
            {
                if (_state.Screen == 1 || _state.Screen == 0)
                {
                    return new RegisterNicknameCommand(_clientProxy, _state);
                }

                return new ProceedScreenCommand(_state);
            }

            return new NullObjectCommand();
        }

        public ICommand CreateLoadRooms()
        {
            return new LoadRoomsCommand(_clientProxy, _state);
        }

        public ICommand CreateLoadMessages()
        {
            return new LoadMessagesCommand(_clientProxy, _state);
        }
    }
}