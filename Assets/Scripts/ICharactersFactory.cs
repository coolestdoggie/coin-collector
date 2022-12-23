using UnityEngine;

public interface ICharactersFactory
{
    void Create(CharacterType characterType, Vector2 position);
}