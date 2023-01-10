using Abstractions;
using UnityEngine;
using Zenject;

public class TeamMemberParallelInfoUpdater : MonoBehaviour, ITickable
{
    [Inject] private ITeamMember _teamMember;

    public void Tick()
    {
        AutoAttackEvaluator.TeamMembersInfo.AddOrUpdate(gameObject, new
        AutoAttackEvaluator.TeamMemberParallelInfo(transform.position, _teamMember.TeamId), (go, value) =>
        {
            value.Position = transform.position;
            value.Team = _teamMember.TeamId;
            return value;
        });
    }

    private void OnDestroy()
    {
        AutoAttackEvaluator.TeamMembersInfo.TryRemove(gameObject, out _);
    }
}
