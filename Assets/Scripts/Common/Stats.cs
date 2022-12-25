using System;
using UnityEngine;

namespace CoinCollector.Common
{
    public class Stats: IStats
    {
        public event Action Updated;
        
        private float _traveledDistance;
        private int _score;
        private SaveData _saveData;

        public Stats()
        {
            _saveData = new SaveData();
            Load();
        }

        public int Score
        {
            get => _score;
            set 
            { 
                _score = value;
                _saveData.Score = _score;
                OnUpdated();
            }
        }

        public float TraveledDistance
        {
            get => _traveledDistance;
            set
            {
                _traveledDistance = value;
                _saveData.TraveledDistance = _traveledDistance;
                OnUpdated();
            }
        }
        
        private void Save()
        {
            SerializationManager.Save("data", _saveData);
        }

        private void Load()
        {
            var saveData = (SaveData) SerializationManager.Load(Application.persistentDataPath + "/saves/data.save");
            if (saveData != null)
            {
                _saveData = saveData;
            }
            
            _score = _saveData.Score;
            _traveledDistance = _saveData.TraveledDistance;
        }

        protected virtual void OnUpdated()
        {
            Save();
            Updated?.Invoke();
        }
    }

}
