using System;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        public Application(State state)
        {
            State = state;
        }

        public void Dispose()
        {
            // clean up
        }

        public void Show()
        {
            State.Screen = 1;
        }

        public State State { get; }
    }
}
