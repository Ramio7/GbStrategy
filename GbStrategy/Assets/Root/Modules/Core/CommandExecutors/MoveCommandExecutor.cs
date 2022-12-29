using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Utils;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        [SerializeField] private HoldCommandExecutor _holdCommandExecutor;

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            if (_holdCommandExecutor.OnHold) _holdCommandExecutor.OnCommandCancel();

            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger("Walk");
            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                .WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger("Idle");
        }
    }
}