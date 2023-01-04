using Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface ISelectable : IHealthContainer, IIconContainer
    {
        Transform ObjectPosition { get; }

        MonoBehaviour HighlighterScript { get; }
    }
}