using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class AttackCommand : IAttackCommand
    {
        public IVictim Target { get; }

        public AttackCommand(IVictim target)
        {
            Target = target;
        }
    }
}