using Abstractions.Assets.Root.Modules.Abstractions;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class HoldCommand : IHoldCommand
    {
        public bool OnHold { get; set; }

        public HoldCommand()
        {
            OnHold = true;
        }

        public void OnDispose()
        {
            OnHold = false;
        }
    }
}