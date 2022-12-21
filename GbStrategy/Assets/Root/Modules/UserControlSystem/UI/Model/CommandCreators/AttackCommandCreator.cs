using Abstractions.Assets.Root.Modules.Abstractions;
using System;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            
        }
    }
}