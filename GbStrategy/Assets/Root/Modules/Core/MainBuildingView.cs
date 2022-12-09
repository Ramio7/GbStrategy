using UnityEngine;

public class MainBuildingView : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    [SerializeField] private Transform _unitsParent;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Sprite Icon => _icon;

    public MonoBehaviour HighlighterScript { get => _highlighterScript; }

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _highlighterScript;

    public override void ExecuteSpecificCommand<IProduceUnitCommand>(IProduceUnitCommand command)
    {
        var unitPrefabProperty = command.GetType().GetProperty("UnitPrefab");
        //Instantiate(command.GetType().GetProperty(nameof(unitPrefabProperty)).GetValue(unitPrefabProperty), new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }
}