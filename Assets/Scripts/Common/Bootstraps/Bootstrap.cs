using CoinCollector.Characters;
using CoinCollector.Common.Spawn;
using UnityEngine;
using Zenject;

namespace CoinCollector.Common.Bootstraps
{
    public class Bootstrap : MonoBehaviour
    {
        private ICharactersFactory _charactersFactory;
        private IInfiniteSpawner _infiniteSpawner;

        [Inject]
        private void Construct(ICharactersFactory charactersFactory, IInfiniteSpawner infiniteSpawner)
        {
            _charactersFactory = charactersFactory;
            _infiniteSpawner = infiniteSpawner;
        }

        private void Start()
        {
            _charactersFactory.Create(CharacterType.Player, Vector2.zero);
            _infiniteSpawner.StartInfiniteSpawn();
        }
    }
}
