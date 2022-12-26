using CoinCollector.Common.RemoteConfig;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CoinCollector.Common.Bootstraps
{
    public class LoadScreenBootstrap : MonoBehaviour
    {
        private RemoteConfigInitializer _remoteConfigInitializer;
        
        [Inject]
        private void Construct(RemoteConfigInitializer remoteConfigInitializer)
        {
            _remoteConfigInitializer = remoteConfigInitializer;
        }       
        
        private void OnEnable()
        {
            _remoteConfigInitializer.Initialized += LoadMainScene;
        }

        private void LoadMainScene()
        {
            SceneManager.LoadScene(1);
        }

        private void OnDisable()
        {
            _remoteConfigInitializer.Initialized -= LoadMainScene;
        }
    }
}