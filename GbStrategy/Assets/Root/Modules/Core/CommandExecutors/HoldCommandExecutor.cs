using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
    {
        [SerializeField] private NavMeshAgent _agent;
        [field: SerializeField] public float DefaultUnitSpeed { get; private set; }

        public override async void ExecuteSpecificCommand(IHoldCommand command)
        {
            DefaultUnitSpeed = _agent.speed;
            _agent.speed = 0;
            //await command.OnDispose();
        }
    }
}