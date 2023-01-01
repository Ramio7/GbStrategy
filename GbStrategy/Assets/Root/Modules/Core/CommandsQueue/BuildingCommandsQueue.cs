using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Core;
using UnityEngine;
using Zenject;

public class BuildingCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject]
    CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;

    public void Clear() { }

    public async void EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
    }
}