using Abstractions.Assets.Root.Modules.Abstractions;
using System;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class HoldCommandCreator : CommandCreatorBase<IHoldCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IHoldCommand> creationCallback)
        {
            
        }
    }
}