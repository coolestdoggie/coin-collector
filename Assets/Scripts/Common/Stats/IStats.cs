using System;

namespace CoinCollector.Common.Stats
{
    public interface IStats
    {
        event Action Updated;
        int Score { get; set; }
        float TraveledDistance { get; set; }
    }
}