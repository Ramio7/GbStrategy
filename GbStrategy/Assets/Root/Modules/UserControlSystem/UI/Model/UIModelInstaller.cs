using Abstractions.Assets.Root.Modules.Abstractions;
using Assets.Root.Modules.UserControlSystem.UI.Model.CommandCreators;
using Assets.Root.Modules.Utils;
using UnityEngine;
using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.Model
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IHoldCommand>>().To<HoldCommandCreator>().AsTransient();

            Container.Bind<CommandTableModel>().AsSingle();
        }
    }
}