using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators;
using Zenject;

public class MouseControlModel
{
    [Inject] private CommandCreatorBase<IMoveCommand> _mover;
    [Inject] private CommandCreatorBase<IAttackCommand> _attacker;

    [Inject]
    public void Init()
    {
        
    }
}
