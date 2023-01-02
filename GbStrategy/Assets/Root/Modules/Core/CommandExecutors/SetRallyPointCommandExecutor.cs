using Assets.Root.Modules.Core;
using System.Threading.Tasks;

public class SetRallyPointCommandExecutor : CommandExecutorBase<ISetRallyPointCommand>
{
    public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
    {
        GetComponent<MainBuildingView>().RallyPoint = command.RallyPoint;
    }
}