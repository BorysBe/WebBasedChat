using System;
using WebBasedChat.Client.Commands;
using WebBasedChat.Client.Factories;
using WebBasedChat.Communication;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        public Application(State state, IClientServiceProxy clientServiceProxy)
        {
            State = state;
            _commandFactory = new CommandFactory(state, clientServiceProxy);
        }

        public void Dispose()
        {
            // clean up
        }

        public void Show()
        {
        }

        public void Proceed()
        {
            State.Screen = 2;
        }

        private readonly CommandFactory _commandFactory;

        private State State { get; }

        public CommandFactory CommandFactory
        {
            get { return _commandFactory; }
        }

        public void Enter(string message)
        {
            this.State.LastMessage = message;
        }
    }
}
