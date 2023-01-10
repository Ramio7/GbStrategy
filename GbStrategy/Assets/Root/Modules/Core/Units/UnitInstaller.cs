using Abstractions;
using UnityEngine;
using Zenject;

public class UnitInstaller : MonoInstaller
{
    [SerializeField] private AttackerParallelnfoUpdater _attackerParallelnfoUpdater;
    [SerializeField] private TeamMemberParallelInfoUpdater _teamMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container.Bind<IDamageDealer>().FromComponentInChildren();
        Container.Bind<ITickable>().FromInstance(_attackerParallelnfoUpdater);
        Container.Bind<ITickable>().FromInstance(_teamMemberParallelInfoUpdater);
        Container.Bind<ITeamMember>().FromComponentInChildren();
        Container.Bind<ICommandsQueue>().FromComponentInChildren();
    }
}