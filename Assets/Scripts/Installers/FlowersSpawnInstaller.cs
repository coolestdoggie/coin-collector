using CoinCollector.Common;
using Zenject;

namespace CoinCollector.Installers
{
    public class FlowersSpawnInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISpawner>().To<FlowersSpawner>().AsSingle();
        }
    }
}