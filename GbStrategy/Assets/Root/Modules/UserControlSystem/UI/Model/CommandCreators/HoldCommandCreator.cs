using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;
using Assets.Root.Modules.Utils;
using System;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class HoldCommandCreator : CommandCreatorBase<IHoldCommand>
    {
        [Inject] private AssetsContext _context;
        private HoldCommand _currentHoldCommand;

        protected override void ClassSpecificCommandCreation(Action<IHoldCommand> creationCallback)
        {
            _currentHoldCommand = new HoldCommand();
            creationCallback?.Invoke(_context.Inject(_currentHoldCommand));
        }

        public override void ProcessCancel() 
        {
            base.ProcessCancel();
            _currentHoldCommand.OnHold = false;
            _currentHoldCommand = null;
        }
    }
}