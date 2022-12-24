using CoinCollector.Factories;
using UnityEngine;
using Zenject;

namespace CoinCollector
{
    public class Bootstrap : MonoBehaviour
    {
        private ICharactersFactory _charactersFactory;

        [Inject]
        private void Construct(ICharactersFactory charactersFactory)
        {
            _charactersFactory = charactersFactory;
        }

        private void Start()
        {
            _charactersFactory.Create(CharacterType.Player, Vector2.zero);
        }
    }
}
