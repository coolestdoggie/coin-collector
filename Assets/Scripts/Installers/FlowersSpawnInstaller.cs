using CoinCollector.Common;
using CoinCollector.Common.Spawn;
using Zenject;

namespace CoinCollector.Installers
{
    public class FlowersSpawnInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInfiniteSpawner>().To<FlowersInfiniteSpawner>().AsSingle();
        }
    }
}