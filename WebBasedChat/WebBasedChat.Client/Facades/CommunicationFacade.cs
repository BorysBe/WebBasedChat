using System;
using WebBasedChat.Client.Facades.Contacts;
using WebBasedChat.Client.Factories.Contracts;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Client.Facades
{
    public class CommunicationFacade : IDisposable, ICommunicationFacade
    {
        private readonly ICommandFactory _commandFactory;
        private State State { get; }

        public CommunicationFacade(State state, ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
            State = state;
        }

        public void Dispose()
        {
            // clean up
        }

        public void Enter(string message)
        {
            this.State.LastMessage = message;
        }

        public void Submit()
        {
            _commandFactory.CreateFrom("Submit").Execute();
        }
        
        public void Proceed()
        {
            _commandFactory.CreateFrom("Proceed").Execute();
        }

        public void LoadRooms()
        {
            _commandFactory.CreateLoadRooms().Execute();
        }

        public void CreateRoom()
        {
            _commandFactory.CreateFrom("Create new room").Execute();
        }

        public void LoadMessages()
        {
            _commandFactory.CreateLoadMessages().Execute();
        }

        public void Join()
        {
            _commandFactory.CreateFrom("Join").Execute();
        }
    }
}
