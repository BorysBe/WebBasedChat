using System.Globalization;
using WebBasedChat.Client.Commands.Contracts;
using WebBasedChat.Client.Models;

namespace WebBasedChat.Client.Commands
{
    public class ProceedScreenCommand : ICommand
    {
        protected readonly State State;

        public ProceedScreenCommand(State state)
        {
            State = state;
        }

        public void Execute()
        {
            switch (State.Screen)
            {
                case 1: State.Screen = 2;
                    break;
                case 2: State.Screen = 3;
                    break;
                case 3: State.Screen = 2;
                    break;
            }
        }
    }
}