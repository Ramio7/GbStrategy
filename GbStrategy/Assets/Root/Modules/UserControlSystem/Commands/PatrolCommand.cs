using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 Target { get; }

        public Vector3 Start { get; }

        public PatrolCommand(Vector3 target, Vector3 start)
        {
            Target = target;
            Start = start;
        }
    }
}