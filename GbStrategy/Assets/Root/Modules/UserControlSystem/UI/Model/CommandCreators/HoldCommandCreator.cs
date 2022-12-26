using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class HoldCommandCreator : CancellableCommandCreatorBase<IHoldCommand, bool>
    {
        protected override IHoldCommand CreateCommand(bool argument) => new HoldCommand();
    }
}