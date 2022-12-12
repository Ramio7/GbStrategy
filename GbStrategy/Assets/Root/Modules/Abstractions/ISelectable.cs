using UnityEngine;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface ISelectable
    {
        float Health { get; }

        float MaxHealth { get; }

        Sprite Icon { get; }

        MonoBehaviour HighlighterScript { get; }
    }
}