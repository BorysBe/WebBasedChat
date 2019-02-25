using System;
using WebBasedChat.Communication;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        private readonly IBus _bus;
        private string _message;

        public Application(State state, IBus bus)
        {
            State = state;
            this._bus = bus;
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

        public void ExecuteOn(string buttonName)
        {
            if (buttonName == "Join")
            {
                State.JoinedChatRoom = State.SelectedChatRoom;
                State.Screen = 3;
            }

            if (buttonName == "Create new room")
            {
                State.RoomsAreReady = true;
            }

            if (buttonName == "Submit")
            {
                if (!string.IsNullOrEmpty(this._message))
                {
                    this._bus.Send(this._message);
                }
            }
        }

        private State State { get; }

        public void Enter(string message)
        {
            this._message = message;
        }
    }
}
