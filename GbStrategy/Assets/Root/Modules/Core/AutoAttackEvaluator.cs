using Abstractions.Assets.Root.Modules.Abstractions;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class AutoAttackEvaluator : MonoBehaviour
{
    public class TeamMemberParallelInfo
    {
        public Vector3 Position;
        public int Team;

        public TeamMemberParallelInfo(Vector3 position, int team)
        {
            Position = position;
            Team = team;
        }
    }

    public class AttackerParallelnfo
    {
        public float VisionRange;
        public ICommand CurrentCommand;

        public AttackerParallelnfo(float visionRadius, ICommand currentCommand)
        {
            VisionRange = visionRadius;
            CurrentCommand = currentCommand;
        }
    }

    public class Command
    {
        public GameObject Attacker;
        public GameObject Target;
        public Command(GameObject attacker, GameObject target)
        {
            Attacker = attacker;
            Target = target;
        }
    }

    public static ConcurrentDictionary<GameObject, AttackerParallelnfo> AttackersInfo = new();
    public static ConcurrentDictionary<GameObject, TeamMemberParallelInfo> TeamMembersInfo = new();
    public static Subject<Command> AutoAttackCommands = new();

    private void Update()
    {
        Parallel.ForEach(AttackersInfo, kvp => Evaluate(kvp.Key, kvp.Value));
    }

    private void Evaluate(GameObject go, AttackerParallelnfo info)
    {
        if (info.CurrentCommand is IMoveCommand)
        {
            return;
        }

        if (info.CurrentCommand is IAttackCommand && info.CurrentCommand is not Command)
        {
            return;
        }

        if (!TeamMembersInfo.TryGetValue(go, out TeamMemberParallelInfo teamInfo))
        {
            return;
        }

        foreach ((GameObject otherGo, TeamMemberParallelInfo otherTeamInfo) in TeamMembersInfo)
        {
            if (teamInfo.Team == otherTeamInfo.Team)
            {
                continue;
            }

            float distance = Vector3.Distance(teamInfo.Position, otherTeamInfo.Position);

            if (distance > info.VisionRange)
            {
                continue;
            }

            AutoAttackCommands.OnNext(new Command(go, otherGo));
            break;
        }
    }
}
