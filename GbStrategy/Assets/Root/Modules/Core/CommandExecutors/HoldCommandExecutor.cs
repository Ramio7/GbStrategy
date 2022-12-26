using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
    {
        public override async void ExecuteSpecificCommand(IHoldCommand command)
        {
            Debug.Log($"{command} initiated");
            await Task.WhenAny();
            Debug.Log($"{command} canceled");
        }
    }
}