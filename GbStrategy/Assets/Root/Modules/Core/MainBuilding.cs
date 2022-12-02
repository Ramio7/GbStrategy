using UnityEngine;

public class MainBuilding : MonoBehaviour, ISelectable, IUnitFactory
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;

    public bool IsSelected { get => _selected; set => _selected = value; }

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    private float _health;
    private bool _selected;
    
    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;

    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0,
        Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }

}
