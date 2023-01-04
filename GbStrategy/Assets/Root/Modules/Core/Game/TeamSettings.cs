using Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamSettings : MonoBehaviour, ITeamMember
{
    public static int TeamCount
    {
        get
        {
            lock (_membersCount)
            {
                return _membersCount.Count;
            }
        }
    }

    public static int GetWinner()
    {
        lock (_membersCount)
        {
            return _membersCount.Keys.First();
        }
    }

    private static Dictionary<int, List<int>> _membersCount = new Dictionary<int, List<int>>();

    public int TeamId => _teamId;

    [SerializeField] private int _teamId;

    private void Awake()
    {
        if (_teamId != 0)
        {
            Register();
        }
    }

    public void SetFaction(int factionId)
    {
        _teamId = factionId;
        Register();
    }

    private void OnDestroy()
    {
        Unregister();
    }

    private void Register()
    {
        lock (_membersCount)
        {
            if (!_membersCount.ContainsKey(_teamId))
            {
                _membersCount.Add(_teamId, new List<int>());
            }
            if (!_membersCount[_teamId].Contains(GetInstanceID()))
            {
                _membersCount[_teamId].Add(GetInstanceID());
            }
        }
    }
    private void Unregister()
    {
        lock (_membersCount)
        {
            if (_membersCount[_teamId].Contains(GetInstanceID()))
            {
                _membersCount[_teamId].Remove(GetInstanceID());
            }
            if (_membersCount[_teamId].Count == 0)
            {
                _membersCount.Remove(_teamId);
            }
        }
    }
}