using System;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        private State State { get; }

        public Application(State state)
        {
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

        public void Show()
        {
        }
    }
}
