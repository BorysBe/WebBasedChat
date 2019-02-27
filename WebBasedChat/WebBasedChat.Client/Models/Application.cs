using System;
using WebBasedChat.Client.Factories.Contracts;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        public Application(State state, ICommandFactory commandFactory)
        {
            State = state;
            _commandFactory = commandFactory;
        }

        public void Dispose()
        {
            // clean up
        }

        private readonly ICommandFactory _commandFactory;

        private State State { get; }

        public void Enter(string message)
        {
            this.State.LastMessage = message;
        }

        public void Show()
        {
        }
    }
}
