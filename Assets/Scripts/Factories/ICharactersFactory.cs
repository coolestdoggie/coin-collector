using UnityEngine;

namespace CoinCollector.Factories
{
    public interface ICharactersFactory
    {
        void Create(CharacterType characterType, Vector2 position);
    }
}