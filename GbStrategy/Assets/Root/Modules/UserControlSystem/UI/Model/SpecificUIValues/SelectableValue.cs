using Abstractions.Assets.Root.Modules.Abstractions;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]

public class SelectableValue : StatefullModifiedValue<ISelectable>
{

}