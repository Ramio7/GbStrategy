namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IHoldCommand : ICommand
    {
        bool OnHold { get; }
        void OnDispose();
    }
}