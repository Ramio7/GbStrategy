using Abstractions.Assets.Root.Modules.Abstractions;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class HoldCommandExecutor : CommandExecutorBase<IHoldCommand>
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _defaultUnitSpeed;

        public bool OnHold { get; private set; }

        public Action OnCommandCancel;

        public override async Task ExecuteSpecificCommand(IHoldCommand command)
        {
            OnHold = command.OnHold;
            if (_defaultUnitSpeed == 0) _defaultUnitSpeed = _agent.speed;
            _agent.speed = 0;
            _animator.SetTrigger("Idle");
            OnCommandCancel += CommandCancel;
        }

        private void CommandCancel()
        {
            _animator.ResetTrigger("Idle");
            _agent.speed = _defaultUnitSpeed;
            OnHold = false;
        }
    }
}