using UnityEngine;
using UniRx;
using Zenject;
using Assets.Root.Modules.Core;
using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;

public class UnitCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IMoveCommand> _moveCommandExecutor;
    [Inject] CommandExecutorBase<IPatrolCommand> _patrolCommandExecutor;
    [Inject] CommandExecutorBase<IAttackCommand> _attackCommandExecutor;
    [Inject] CommandExecutorBase<IStopCommand> _stopCommandExecutor;
    [Inject] CommandExecutorBase<IHoldCommand> _holdCommandExecutor;

    private ReactiveCollection<ICommand> _innerCollection = new();

    public ICommand CurrentCommand => _innerCollection.Count > 0 ? _innerCollection[0] : default;

    [Inject]
    private void Init()
    {
        _innerCollection.ObserveAdd().Subscribe(OnNewCommand).AddTo(this);
    }

    private void OnNewCommand(ICommand command, int index)
    {
        if (index == 0)
        {
            ExecuteCommand(command);
        }
    }

    private async void ExecuteCommand(ICommand command)
    {
        await _moveCommandExecutor.TryExecuteCommand(command);
        await _patrolCommandExecutor.TryExecuteCommand(command);
        await _attackCommandExecutor.TryExecuteCommand(command);
        await _stopCommandExecutor.TryExecuteCommand(command);
        await _holdCommandExecutor.TryExecuteCommand(command);

        if (_innerCollection.Count > 0)
        {
            _innerCollection.RemoveAt(0);
        }
        CheckTheQueue();
    }

    private void CheckTheQueue()
    {
        if (_innerCollection.Count > 0)
        {
            ExecuteCommand(_innerCollection[0]);
        }
    }

    public void EnqueueCommand(object wrappedCommand)
    {
        var command = wrappedCommand as ICommand;
        _innerCollection.Add(command);
    }

    public void Clear()
    {
        _innerCollection.Clear();
        _stopCommandExecutor.ExecuteSpecificCommand(new StopCommand());
    }
}
