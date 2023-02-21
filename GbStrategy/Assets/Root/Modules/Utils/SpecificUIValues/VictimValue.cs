using Assets.Root.Modules.Abstractions;
using UnityEngine;

namespace Assets.Root.Modules.Utils
{
    [CreateAssetMenu(fileName = nameof(VictimValue), menuName = "Strategy Game/" + nameof(VictimValue), order = 0)]

    public class VictimValue : StatelessModifiedValue<IVictim>
    {

    }
}