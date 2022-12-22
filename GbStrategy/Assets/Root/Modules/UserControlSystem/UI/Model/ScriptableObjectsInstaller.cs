using Assets.Root.Modules.UserControlSystem.UI.Model;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectsInstaller", menuName = "Installers/ScriptableObjectsInstaller")]
public class ScriptableObjectsInstaller : ScriptableObjectInstaller<ScriptableObjectsInstaller>
{
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private VictimValue _victimValue;
    [SerializeField] private SelectableValue _selectableValue;
    public override void InstallBindings()
    {
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<VictimValue>().FromInstance(_victimValue);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);
    }
}