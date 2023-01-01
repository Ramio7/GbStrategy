using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;

        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patrols from {command.Start} to {command.Target}");
        }
    }
}