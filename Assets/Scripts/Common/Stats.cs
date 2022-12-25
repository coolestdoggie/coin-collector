using System;

namespace CoinCollector.Common
{
    public class Stats: IStats
    {
        public event Action Updated;
        
        private float _traveledDistance;
        private int _score;


        public int Score
        {
            get => _score;
            set 
            { 
                _score = value;
                OnUpdated();
            }
        }

        public float TraveledDistance
        {
            get => _traveledDistance;
            set
            {
                _traveledDistance = value;
                OnUpdated();
            }
        }

        protected virtual void OnUpdated()
        {
            Updated?.Invoke();
        }
    }

}
