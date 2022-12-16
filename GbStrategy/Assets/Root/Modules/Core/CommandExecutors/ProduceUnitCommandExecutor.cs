using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        [SerializeField] private Transform _unitsContainer;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), transform.position.y,
                Random.Range(transform.position.z - 10, transform.position.z + 10)), Quaternion.identity, _unitsContainer);
        }
    }
}