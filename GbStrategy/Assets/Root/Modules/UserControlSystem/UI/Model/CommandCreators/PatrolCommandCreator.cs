using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;
using Assets.Root.Modules.Utils;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private SelectableValue _selectable;

        private Action<IPatrolCommand> _creationCallback;

        [Inject] private void Init(Vector3Value groundClicks) => groundClicks.OnNewValue += ONNewValue;

        private void ONNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(_selectable.CurrentValue.ObjectPosition.position, groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback) => _creationCallback = creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}