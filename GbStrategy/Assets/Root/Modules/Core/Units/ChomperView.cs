using Abstractions;
using Assets.Root.Modules.Core.CommandExecutors;
using Assets.Root.Modules.UserControlSystem.Commands;
using System.Threading.Tasks;
using UnityEngine;

public class ChomperView : MonoBehaviour, IUnit
{
    public int TeamId => _teamId;

    public int Damage => _damage;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public MonoBehaviour HighlighterScript { get => _highlighterScript; }

    public Transform ObjectPosition => _unitPosition;

    public float VisionRange { get => _visionRange; }

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _highlighterScript;

    [SerializeField] private int _teamId;
    [SerializeField] private int _damage;
    [SerializeField] private float _visionRange;

    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommandExecutor;

    private Transform _unitPosition;

    private void Start()
    {
        _unitPosition = transform;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            return;
        }
        _health -= damage;
        if (_health <= 0)
        {            
            KillUnit();
        }
    }

    private async void KillUnit()
    {
        await _stopCommandExecutor.ExecuteSpecificCommand(new StopCommand());
        _animator.SetTrigger("Dead");
        await Task.Delay(1000);
        Destroy(gameObject);
    }
}
