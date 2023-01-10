using Abstractions;
using UnityEngine;
using Zenject;

public class BuildingInstaller : MonoInstaller
{
    [SerializeField] private TeamMemberParallelInfoUpdater _teamMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container.Bind<ITickable>().FromInstance(_teamMemberParallelInfoUpdater);
        Container.Bind<ITeamMember>().FromComponentInChildren();
    }
}