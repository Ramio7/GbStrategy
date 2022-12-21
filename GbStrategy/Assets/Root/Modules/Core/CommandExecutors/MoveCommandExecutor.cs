using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}");
        }
    }
}