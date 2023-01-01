using Zenject;

namespace Assets.Root.Modules.UserControlSystem.UI.View
{
    public class UIViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ObjectStatusTableView>().FromComponentInHierarchy().AsSingle();
        }
    }
}