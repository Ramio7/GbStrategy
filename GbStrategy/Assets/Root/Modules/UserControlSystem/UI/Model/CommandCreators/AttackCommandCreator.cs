using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.Commands;

namespace Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IVictim>
    {
        protected override IAttackCommand CreateCommand(IVictim argument) => new AttackCommand(argument);
    }
}