using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"Patrol command initialized");
        }
    }
}