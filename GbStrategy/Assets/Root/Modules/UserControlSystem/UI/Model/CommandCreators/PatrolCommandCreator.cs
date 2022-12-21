using Abstractions.Assets.Root.Modules.Abstractions;
using System;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            
        }
    }
}