using System.Collections.Generic;
using System.Linq;
using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class LoadRoomsCommand : ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private readonly State _state;

        public LoadRoomsCommand(IClientServiceProxy clientServiceProxy, State state)
        {
            _clientServiceProxy = clientServiceProxy;
            _state = state;
        }

        public void Execute()
        {
            var rooms = _clientServiceProxy.GetRooms();
            _state.Rooms = rooms.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}