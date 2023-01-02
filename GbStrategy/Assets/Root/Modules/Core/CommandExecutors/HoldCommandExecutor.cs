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

        public Action CommandCancel { get; private set; }

        public bool OnHold { get; private set; }

        public override async Task ExecuteSpecificCommand(IHoldCommand command)
        {
            OnHold = command.OnHold;
            _animator.SetBool("Idle", true);
            _animator.SetBool("Walk", false);
            if (_defaultUnitSpeed == 0) _defaultUnitSpeed = _agent.speed;
            _agent.speed = 0;
            CommandCancel += OnCommandCancel;
        }

        public void OnCommandCancel()
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Idle", false);
            _agent.speed = _defaultUnitSpeed;
            OnHold = false;;
        }
    }
}