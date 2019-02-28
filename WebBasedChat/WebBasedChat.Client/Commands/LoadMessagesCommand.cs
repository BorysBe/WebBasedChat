using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class LoadMessagesCommand : ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private readonly State _state;

        public LoadMessagesCommand(IClientServiceProxy clientServiceProxy, State state)
        {
            _clientServiceProxy = clientServiceProxy;
            _state = state;
        }

        public void Execute()
        {
            _state.Messages = _clientServiceProxy.Last(30);
        }
    }
}