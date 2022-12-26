using Unity.Services.RemoteConfig;

namespace CoinCollector.Common
{
    public static class ConfigValues
    {
        public static readonly int MAX_AMOUNT_OF_FLOWERS = RemoteConfigService.Instance.appConfig.GetInt("maxAmountOfFlowers");
        public static readonly int MS_BTW_FLOWERS_SPAWN = RemoteConfigService.Instance.appConfig.GetInt("msBetweenFlowersSpawn");
        public static readonly float PLAYER_SPEED = RemoteConfigService.Instance.appConfig.GetFloat("playerSpeed");
        public static readonly string PLAYER_LAYER_MASK =
            RemoteConfigService.Instance.appConfig.GetString("playerLayerMask");
    }
}