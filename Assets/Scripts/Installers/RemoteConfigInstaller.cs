using CoinCollector.Common.RemoteConfig;
using Zenject;

namespace CoinCollector.Installers
{
    public class RemoteConfigInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<RemoteConfigInitializer>().AsSingle().NonLazy();
        }
    }
}