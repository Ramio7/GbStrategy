using Abstractions.Assets.Root.Modules.Abstractions;
using System;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            
        }
    }
}