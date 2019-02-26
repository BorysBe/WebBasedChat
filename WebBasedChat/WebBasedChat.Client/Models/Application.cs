using System;
using WebBasedChat.Communication;

namespace WebBasedChat.Client.Models
{
    public class Application : IDisposable
    {
        private readonly IClientServiceProxy _clientServiceProxy;
        private string _message;

        public Application(State state, IClientServiceProxy clientServiceProxy)
        {
            State = state;
            this._clientServiceProxy = clientServiceProxy;
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

        private static int roomIdx;

        public void ExecuteOn(string buttonName)
        {
            if (buttonName == "Join")
            {
                State.JoinedChatRoom = State.SelectedChatRoom;
                State.Screen = 3;
            }

            if (buttonName == "Create new room")
            {
                var roomId = _clientServiceProxy.CreateRoom("room" + roomIdx++);
                State.RoomsAreReady = true;
            }

            if (buttonName == "Submit")
            {
                if (!string.IsNullOrEmpty(this._message))
                {
                    this._clientServiceProxy.Send(this._message);
                }
            }

            if (buttonName == "Back")
            {
                State.Screen = 2;
            }
        }

        private State State { get; }

        public void Enter(string message)
        {
            this._message = message;
        }
    }
}
