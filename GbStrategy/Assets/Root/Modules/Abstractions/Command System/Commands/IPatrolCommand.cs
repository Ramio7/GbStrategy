using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IPatrolCommand : ICommand
    {
        Vector3 Target { get; }

        Vector3 Start { get; }
    }
}
