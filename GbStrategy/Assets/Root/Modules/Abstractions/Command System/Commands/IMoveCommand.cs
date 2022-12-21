using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IMoveCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}