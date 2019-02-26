using WebBasedChat.Client.Commands.Contracts;

namespace WebBasedChat.Client.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateFrom(string buttonName);
    }
}