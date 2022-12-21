using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;
using Assets.Root.Modules.Utils;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IMoveCommand> _creationCallback;

        [Inject] private void Init(Vector3Value groundClicks) => groundClicks.OnNewValue += ONNewValue;

        private void ONNewValue(Vector3 groundClick) 
        {
            _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
            _creationCallback= null;
        }

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback) => _creationCallback= creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback= null;
        }
    }
}