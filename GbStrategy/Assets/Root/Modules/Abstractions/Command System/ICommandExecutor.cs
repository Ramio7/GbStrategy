using System.Threading.Tasks;

public interface ICommandExecutor
{
}

public interface ICommandExecutor<T> : ICommandExecutor where T : ICommand
{
    Task ExecuteSpecificCommand(T command);
}