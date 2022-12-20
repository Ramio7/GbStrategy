using Abstractions.Assets.Root.Modules.Abstractions;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" +
nameof(SelectableValue), order = 0)]

public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public Action<ISelectable> onSelected;

    public void SetValue(ISelectable value)
    {
        CurrentValue = value;
        onSelected?.Invoke(value);
    }
}