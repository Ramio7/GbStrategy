using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking {command.Target}");
        }
    }
}