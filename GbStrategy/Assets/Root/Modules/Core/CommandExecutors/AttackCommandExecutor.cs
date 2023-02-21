using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Core.CommandExecutors;
using Assets.Root.Modules.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Assets.Root.Modules.Abstractions;
using Abstractions;
using Assets.Root.Modules.Utils;

public partial class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;
    [SerializeField] private float _attackingDistance;
    [SerializeField] private int _attackingPeriod;
    
    private IHealthContainer _ourHealth;
    private Vector3 _ourPosition;
    private Vector3 _targetPosition;
    private Quaternion _ourRotation;
    private readonly Subject<Vector3> _targetPositions = new();
    private readonly Subject<Quaternion> _targetRotations = new();
    private readonly Subject<IVictim> _attackTargets = new();

    private Transform _targetTransform;
    private AttackOperation _currentAttackOp;

    public class AttackOperation : IAwaitable<AsyncExtensions.Void>
    {
        public class AttackOperationAwaiter : AwaiterBase<AsyncExtensions.Void>
        {
            private readonly AttackOperation _attackOperation;

            public AttackOperationAwaiter(AttackOperation attackOperation)
            {
                _attackOperation = attackOperation;
                attackOperation.OnComplete += OnOperationComplete;
            }

            private void OnOperationComplete()
            {
                _attackOperation.OnComplete -= OnOperationComplete;
                OnWaitFinish(new AsyncExtensions.Void());
            }
        }

        private event Action OnComplete;
        private AttackCommandExecutor _attackCommandExecutor;
        private readonly IVictim _target;
        private bool _isCancelled;
        private readonly Thread _attackThread;
        private readonly MainThreadDispatcher _mainThreadDispatcher;

        public AttackOperation(AttackCommandExecutor attackCommandExecutor,
        IVictim target)
        {
            _target = target;
            _attackCommandExecutor = attackCommandExecutor;
            _attackThread = new Thread(AttackAlgorythm);
            _attackThread.Start();
        }

        public void Cancel()
        {
            _isCancelled = true;
            _attackThread.Interrupt();
            OnComplete?.Invoke();
        }

        private void AttackAlgorythm(object obj)
        {
            while (_attackCommandExecutor != null
                || _attackCommandExecutor._ourHealth.Health > 0
                || _target.Health > 0
                || !_isCancelled)
            {
                var targetPosition = default(Vector3);
                var ourPosition = default(Vector3);
                var ourRotation = default(Quaternion);
                lock (_attackCommandExecutor)
                {
                    targetPosition = _attackCommandExecutor._targetPosition;
                    ourPosition = _attackCommandExecutor._ourPosition;
                    ourRotation = _attackCommandExecutor._ourRotation;
                }
                var vector = targetPosition - ourPosition;
                var distanceToTarget = vector.magnitude;
                if (distanceToTarget > _attackCommandExecutor._attackingDistance)
                {
                    var finalDestination = targetPosition - vector.normalized * (_attackCommandExecutor._attackingDistance * 0.9f);
                    _attackCommandExecutor
                    ._targetPositions.OnNext(finalDestination);
                    Thread.Sleep(100);
                }
                else if (ourRotation != Quaternion.LookRotation(vector))
                {
                    _attackCommandExecutor.
                    _targetRotations
                    .OnNext(Quaternion.LookRotation(vector));
                }
                else
                {
                    _attackCommandExecutor._attackTargets.OnNext(_target);
                    Thread.Sleep(_attackCommandExecutor._attackingPeriod);
                }
            }

            OnComplete?.Invoke();
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter()
        {
            return new AttackOperationAwaiter(this);
        }
    }


    [Inject]
    private void Init()
    {
        _targetPositions
        .Select(value => new Vector3((float)Math.Round(value.x, 2),
        (float)Math.Round(value.y, 2), (float)Math.Round(value.z, 2)))
        .Distinct()
        .ObserveOnMainThread()
        .Subscribe(StartMovingToPosition);
        _attackTargets
        .ObserveOnMainThread()
        .Subscribe(StartAttackingTargets);
        _targetRotations
        .ObserveOnMainThread()
        .Subscribe(SetAttackRoation);
    }

    private void SetAttackRoation(Quaternion targetRotation)
    {
        transform.rotation = targetRotation;
    }

    private void StartAttackingTargets(IVictim target)
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().ResetPath();
        _animator.SetTrigger("Attack");
        target.TakeDamage(GetComponent<IDamageDealer>().Damage);
    }

    private void StartMovingToPosition(Vector3 position)
    {
        GetComponent<NavMeshAgent>().destination = position;
        _animator.SetTrigger("Walk");
    }

    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        _targetTransform = (command.Target as Component).transform;
        _currentAttackOp = new AttackOperation(this, command.Target);
        Update();
        _stopCommandExecutor.CancellationTokenSource = new
        CancellationTokenSource();
        try
        {
            await
            _currentAttackOp.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
        }
        catch
        {
            _currentAttackOp.Cancel();
        }
        _animator.SetTrigger("Idle");
        _currentAttackOp = null;
        _targetTransform = null;
        _stopCommandExecutor.CancellationTokenSource = null;
    }

    private void Start()
    {
        _ourHealth = GetComponentInParent<IHealthContainer>();
    }

    private void Update()
    {
        if (_currentAttackOp == null)
        {
            return;
        }
        lock (this)
        {
            _ourPosition = transform.position;
            _ourRotation = transform.rotation;
            if (_targetTransform != null)
            {
                _targetPosition = _targetTransform.position;
            }
        }
    }
}
