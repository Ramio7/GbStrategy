using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.Model;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]

public class SelectableValue : ModifiedValue<ISelectable>
{

}