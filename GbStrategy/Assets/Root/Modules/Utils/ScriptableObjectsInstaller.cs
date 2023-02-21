using Abstractions;
using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Utils;
using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectsInstaller", menuName = "Installers/ScriptableObjectsInstaller")]
public class ScriptableObjectsInstaller : ScriptableObjectInstaller<ScriptableObjectsInstaller>
{
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private VictimValue _victimValue;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private AssetsContext _context;
    [SerializeField] private BoolValue _boolValue;

    public override void InstallBindings()
    {
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<VictimValue>().FromInstance(_victimValue);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<BoolValue>().FromInstance(_boolValue);
        Container.Bind<AssetsContext>().FromInstance(_context);
        Container.Bind<IAwaitable<IVictim>>().FromInstance(_victimValue);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectableValue);
    }
}