using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Utils;
using UnityEngine;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper")] private GameObject _unitPrefab;
    }
}