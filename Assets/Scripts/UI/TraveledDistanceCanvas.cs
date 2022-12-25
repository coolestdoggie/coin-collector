using System;
using CoinCollector.Common;
using TMPro;
using UnityEngine;
using Zenject;

namespace CoinCollector.UI
{
    public class TraveledDistanceCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _distanceText;
        private IStats _stats;
        
        [Inject]
        private void Construct(IStats stats)
        {
            _stats = stats;
        }

        private void OnEnable()
        {
            _stats.Updated += UpdateDistanceText;
        }

        private void Start()
        {
            UpdateDistanceText();
        }

        private void UpdateDistanceText()
        {
            float traveledDistance = _stats.TraveledDistance;
            string formattedTraveledDistance = Math.Round(traveledDistance, 1).ToString();
            
            _distanceText.text = formattedTraveledDistance;
        }

        private void OnDisable()
        {
            _stats.Updated -= UpdateDistanceText;
        }
    }
}
