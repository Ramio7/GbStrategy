using Assets.Root.Modules.UserControlSystem.UI.Model;
using Assets.Root.Modules.Utils;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectsInstaller", menuName = "Installers/ScriptableObjectsInstaller")]
public class ScriptableObjectsInstaller : ScriptableObjectInstaller<ScriptableObjectsInstaller>
{
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private VictimValue _victimValue;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private AssetsContext _context;

    public override void InstallBindings()
    {
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<VictimValue>().FromInstance(_victimValue);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
        Container.Bind<AssetsContext>().FromInstance(_context);
    }
}