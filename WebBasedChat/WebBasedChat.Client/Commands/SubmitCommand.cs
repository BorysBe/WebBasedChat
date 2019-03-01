using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class SubmitCommand : ICommand
    {
        private readonly IClientServiceProxy _clientProxy;
        private readonly State _state;

        public SubmitCommand(IClientServiceProxy clientProxy, State state)
        {
            _clientProxy = clientProxy;
            _state = state;
        }

        public void Execute()
        {
            if (!string.IsNullOrEmpty(_state.LastMessage))
            {
                _clientProxy.Send(_state.LastMessage, (int)_state.JoinedChatRoom);
            }
        }
    }
}