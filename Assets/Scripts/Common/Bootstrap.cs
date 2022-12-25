using CoinCollector.Characters;
using UnityEngine;
using Zenject;

namespace CoinCollector.Common
{
    public class Bootstrap : MonoBehaviour
    {
        private ICharactersFactory _charactersFactory;
        private ISpawner _spawner;

        [Inject]
        private void Construct(ICharactersFactory charactersFactory, ISpawner spawner)
        {
            _charactersFactory = charactersFactory;
            _spawner = spawner;
        }

        private void Start()
        {
            _charactersFactory.Create(CharacterType.Player, Vector2.zero);
            _spawner.SpawnOneObject();
        }
    }
}
