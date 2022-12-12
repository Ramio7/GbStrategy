using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
}