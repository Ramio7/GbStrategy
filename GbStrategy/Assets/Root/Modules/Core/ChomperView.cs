using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

public class ChomperView : MonoBehaviour, ISelectable
{
    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public MonoBehaviour HighlighterScript { get => _highlighterScript; }

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _highlighterScript;
}