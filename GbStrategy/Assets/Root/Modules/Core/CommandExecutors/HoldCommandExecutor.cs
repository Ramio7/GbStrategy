using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
    {
        public override void ExecuteSpecificCommand(IHoldCommand command)
        {
            Debug.Log($"{name} holds position");
        }
    }
}