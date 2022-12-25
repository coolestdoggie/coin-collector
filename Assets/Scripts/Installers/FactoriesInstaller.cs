using CoinCollector.Characters;
using Zenject;

namespace CoinCollector.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        private CharactersFactory _charactersFactory;
    
        public override void InstallBindings()
        {
            Container.Bind<ICharactersFactory>().To<CharactersFactory>().AsSingle();
        }
    }
}