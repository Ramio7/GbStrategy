using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core
{
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

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), transform.position.y, 
                Random.Range(transform.position.z  - 10, transform.position.z + 10)), Quaternion.identity, _unitsParent);
        }
    }
}