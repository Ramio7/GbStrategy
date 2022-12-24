using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) => new PatrolCommand(_selectable.CurrentValue.ObjectPosition.position, argument);
    }
}