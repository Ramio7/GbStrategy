using Assets.Root.Modules.Abstractions;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IAttackCommand : ICommand
    {
        IVictim Target { get; }
    }
}