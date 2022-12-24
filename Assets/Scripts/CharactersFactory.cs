using UnityEngine;
using Zenject;

public class CharactersFactory : ICharactersFactory
{
    private readonly DiContainer _diContainer;
    public CharactersFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }
    
    public void Create(CharacterType characterType, Vector2 position)
    {
        GameObject prefab = null;
        switch (characterType)
        {
            case CharacterType.Player:
            {
                prefab = Resources.Load("Characters/Player") as GameObject;
                
                PlayerModel playerModel = new PlayerModel();
                GameObject gameObject = _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
                PlayerView playerView = gameObject.GetComponent<PlayerView>();
                
                playerView.Init(playerModel);
                break;
            }
            case CharacterType.Flower:
            {
                prefab = Resources.Load("Characters/Flower") as GameObject;
                break;
            }
        }


        if (prefab == null)
        {
            return;
        }
        
    }
    
}