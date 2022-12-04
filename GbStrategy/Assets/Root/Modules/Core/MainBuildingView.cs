using UnityEngine;

public class MainBuildingView : MonoBehaviour, ISelectable, IUnitFactory
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public MonoBehaviour HighlighterScript { get => _highlighterScript; }

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _highlighterScript;

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0,
        Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }

}
