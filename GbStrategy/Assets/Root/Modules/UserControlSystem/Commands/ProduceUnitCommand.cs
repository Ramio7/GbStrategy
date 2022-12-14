using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Utils;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class ProduceUnitCommand : Command, IProduceUnitCommand
    {
        [Inject(Id = "Chomper")] public string UnitName { get; }
        [Inject(Id = "Chomper")] public Sprite Icon { get; }
        [Inject(Id = "Chomper")] public float ProductionTime { get; }
        public GameObject UnitPrefab => _unitPrefab;

        [InjectAsset("Chomper")] private GameObject _unitPrefab;
    }
}