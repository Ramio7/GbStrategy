using Abstractions.Assets.Root.Modules.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Root.Modules.Core.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public override async Task ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}