using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IProduceUnitCommand : ICommand, IIconContainer
    {
        float ProductionTime { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }

    }
}