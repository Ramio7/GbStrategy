using Abstractions;
using UnityEngine;

public class TeamSettings : MonoBehaviour, ITeamMember
{
    public int TeamId => _TeamId;
    [SerializeField] private int _TeamId;
    public void SetFaction(int TeamId)
    {
        _TeamId = TeamId;
    }
}