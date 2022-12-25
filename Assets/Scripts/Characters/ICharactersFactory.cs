using UnityEngine;

namespace CoinCollector.Characters
{
    public interface ICharactersFactory
    {
        GameObject Create(CharacterType characterType, Vector2 position);
    }
}