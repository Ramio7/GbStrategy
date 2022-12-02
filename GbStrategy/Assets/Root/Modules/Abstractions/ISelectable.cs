using UnityEngine;

public interface ISelectable
{
    bool IsSelected { get; set; }

    float Health { get; }

    float MaxHealth { get; }

    Sprite Icon { get; }
}
