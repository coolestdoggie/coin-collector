using UnityEngine;

public class CharactersFactory : ICharactersFactory
{
    public void Create(CharacterType characterType, Vector2 position)
    {
        GameObject gameObjectToCreate = null;
        switch (characterType)
        {
            case CharacterType.Player:
            {
                gameObjectToCreate = Resources.Load("Characters/Player") as GameObject;
                
                PlayerModel playerModel = new PlayerModel();
                var playerView = GameObject.Instantiate(gameObjectToCreate, position, Quaternion.identity)
                    .GetComponent<PlayerView>();
                playerView.Init(playerModel);
                break;
            }
            case CharacterType.Flower:
            {
                gameObjectToCreate = Resources.Load("Characters/Flower") as GameObject;
                break;
            }
        }


        if (gameObjectToCreate == null)
        {
            return;
        }
        
    }
    
}