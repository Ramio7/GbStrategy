using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;
using Assets.Root.Modules.Utils;
using System;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class ProduceUnitCommandCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommand()));
        }
    }
}