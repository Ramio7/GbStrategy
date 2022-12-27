using System.Threading.Tasks;

namespace Abstractions.Assets.Root.Modules.Abstractions
{
    public interface IHoldCommand : ICommand
    {
        bool OnHold { get; }
        Task OnDispose();
    }
}