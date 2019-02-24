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
        }

        private State State { get; }
    }
}
