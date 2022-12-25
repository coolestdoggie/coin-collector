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

        private void UpdateDistanceText()
        {
            _distanceText.text = _stats.TraveledDistance.ToString();
        }

        private void OnDisable()
        {
            _stats.Updated -= UpdateDistanceText;
        }
    }
}
