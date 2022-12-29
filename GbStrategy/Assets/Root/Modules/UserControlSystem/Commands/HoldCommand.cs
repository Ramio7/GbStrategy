using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading.Tasks;

namespace Assets.Root.Modules.UserControlSystem.Commands
{
    public class HoldCommand : Command, IHoldCommand
    {
        public bool OnHold { get; set; }

        public HoldCommand()
        {
            OnHold = true;
        }

        public Task OnDispose()
        {
            return Task.FromResult(OnHold = false);
        }
    }
}