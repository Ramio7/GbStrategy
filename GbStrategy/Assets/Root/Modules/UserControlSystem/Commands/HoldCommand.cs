using Abstractions.Assets.Root.Modules.Abstractions;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class HoldCommand : IHoldCommand
    {
        public bool OnHold { get; }

        public HoldCommand()
        {
            OnHold = true;
        }

    }
}