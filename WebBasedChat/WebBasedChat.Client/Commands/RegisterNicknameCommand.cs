using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class RegisterNicknameCommand : ProceedScreenCommand, ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;

        public RegisterNicknameCommand(IClientServiceProxy clientServiceProxy, State state) : base(state)
        {
            _clientServiceProxy = clientServiceProxy;
        }

        public new void Execute()
        {
            var userId = _clientServiceProxy.RegisterUser(State.Name);
            State.UserId = userId;
            base.Execute();
        }
    }
}