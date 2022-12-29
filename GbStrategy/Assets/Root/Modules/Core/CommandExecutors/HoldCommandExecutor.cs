using Abstractions.Assets.Root.Modules.Abstractions;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _defaultUnitSpeed;

        public Action OnCommandCancel;

        public override void ExecuteSpecificCommand(IHoldCommand command)
        {
            if (_defaultUnitSpeed == 0) _defaultUnitSpeed = _agent.speed;
            _agent.speed = 0;
            Debug.Log($"Unit base speed {_defaultUnitSpeed}");
            Debug.Log($"Unit hold speed {_agent.speed}");
            OnCommandCancel += CommandCancel;
        }

        private void CommandCancel()
        {
            _agent.speed = _defaultUnitSpeed;
        }
    }
}