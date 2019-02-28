﻿using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;
using WebBasedChat.Communication.Contracts;

namespace WebBasedChat.Client.Commands
{
    public class CreateRoomCommand : ICommand
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private readonly State _state;

        public CreateRoomCommand(IClientServiceProxy clientServiceProxy, State state)
        {
            _clientServiceProxy = clientServiceProxy;
            _state = state;
        }

        private static int _roomIdx;

        public void Execute()
        {
            var roomName = "room" + _roomIdx++;
            var roomId = _clientServiceProxy.CreateRoom(roomName);
            if (!_state.Rooms.ContainsKey(roomName))
            {
                _state.Rooms.Add(roomName, roomId);
            }

            _state.SelectedChatRoom = roomId;
        }
    }
}