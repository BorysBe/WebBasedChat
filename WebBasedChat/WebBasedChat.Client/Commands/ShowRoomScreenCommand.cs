using System.Globalization;
using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class ShowRoomScreenCommand : ICommand
    {
        protected readonly State State;

        public ShowRoomScreenCommand(State state)
        {
            State = state;
        }

        public void Execute()
        {
            State.Screen = 2;
        }
    }

    public class RegisterNicknameCommand : ShowRoomScreenCommand, ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;

        public RegisterNicknameCommand(IClientServiceProxy clientServiceProxy, State state) : base(state)
        {
            _clientServiceProxy = clientServiceProxy;
        }

        public void Execute()
        {
            var userId = _clientServiceProxy.RegisterUser(State.Name);
            base.Execute();
        }
    }
}