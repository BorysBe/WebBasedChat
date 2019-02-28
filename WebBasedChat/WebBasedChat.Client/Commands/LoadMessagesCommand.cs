using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var newMessages = _clientServiceProxy.Last(30);
            var existingMessages = _state.Messages.ToList();
            existingMessages.AddRange(newMessages);
            
            _state.Messages = existingMessages.GroupBy(x => new { x.UserName, x.Content }).Select(g => g.First()).ToList();

        }
    }
}