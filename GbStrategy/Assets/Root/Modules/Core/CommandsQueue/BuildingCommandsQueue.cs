using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Core;
using UnityEngine;
using Zenject;

public class BuildingCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
    [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;

    public ICommand CurrentCommand => default;

    public void Clear() { }

    public async void EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
        await _setRallyPointCommandExecutor.TryExecuteCommand(command);
    }
}