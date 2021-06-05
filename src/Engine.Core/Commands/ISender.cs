namespace Engine.Core.Commands
{
    public interface ISender
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
