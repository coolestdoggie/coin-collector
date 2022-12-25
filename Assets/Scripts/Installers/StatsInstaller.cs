using CoinCollector.Common;
using Zenject;

namespace CoinCollector.Installers
{
    public class StatsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IStats>()
                .To<Stats>()
                .AsSingle();
        }
    }
}