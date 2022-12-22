using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using UnityEngine;

public class ChomperView : MonoBehaviour, ISelectable, IVictim
{
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public MonoBehaviour HighlighterScript { get => _highlighterScript; }

    public Transform ObjectPosition => _unitPosition;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _highlighterScript;

    private Transform _unitPosition;

    private void Start()
    {
        _unitPosition = transform;
    }
}
