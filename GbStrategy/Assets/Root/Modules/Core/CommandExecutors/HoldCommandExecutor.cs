using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading.Tasks;
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
            Debug.Log($"Unit base speed {DefaultUnitSpeed}");
            await Task.WhenAll(command.OnDispose());
            Debug.Log($"Unit hold speed {DefaultUnitSpeed}");
            _agent.speed = DefaultUnitSpeed;
            Debug.Log($"Current unit speed {_agent.speed}");
        }
    }
}