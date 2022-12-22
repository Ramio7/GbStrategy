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

        protected override void ClassSpecificCommandCreation(Action<IHoldCommand> creationCallback) => creationCallback?.Invoke(_context.Inject(new HoldCommand()));
    }
}