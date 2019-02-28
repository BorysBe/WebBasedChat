using System;
using WebBasedChat.Client.Factories.Contracts;

namespace WebBasedChat.Client.Models
{
    public class CommunicationFacade : IDisposable
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

        public void Show()
        {
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

        public void LoadMesages()
        {
            _commandFactory.CreateLoadMessages().Execute();
        }

        public void Join()
        {
            _commandFactory.CreateFrom("Join").Execute();
        }
    }
}
