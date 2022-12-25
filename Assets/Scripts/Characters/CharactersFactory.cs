using CoinCollector.Characters.Flower;
using CoinCollector.Characters.Player;
using UnityEngine;
using Zenject;

namespace CoinCollector.Characters
{
    public class CharactersFactory : ICharactersFactory
    {
        private readonly DiContainer _diContainer;
        public CharactersFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
    
        public GameObject Create(CharacterType characterType, Vector2 position)
        {
            GameObject prefab = null;
            GameObject createdGameObject = null;
            switch (characterType)
            {
                case CharacterType.Player:
                {
                    prefab = Resources.Load("Characters/Player") as GameObject;
                
                    PlayerModel playerModel = new PlayerModel();
                    createdGameObject = _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
                    PlayerView playerView = createdGameObject.GetComponent<PlayerView>();
                
                    playerView.Init(playerModel);
                    break;
                }
                case CharacterType.Flower:
                {
                    prefab = Resources.Load("Characters/Flower") as GameObject;
                    
                    FlowerModel flowerModel = new FlowerModel();
                    createdGameObject = _diContainer.InstantiatePrefab(prefab, position, Quaternion.identity, null);
                    FlowerView flowerView = createdGameObject.GetComponent<FlowerView>();

                    flowerView.Init();
                    break;
                }
            }

            return createdGameObject;
        }
        
    
    }
}