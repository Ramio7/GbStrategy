using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.Abstractions;

public class AutoAttackCommand : IAttackCommand
{
    public IVictim Target { get; }

    public AutoAttackCommand(IVictim target)
    {
        Target = target;
    }
}
