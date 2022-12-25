using CoinCollector.Common;
using TMPro;
using UnityEngine;
using Zenject;

namespace CoinCollector.UI
{
    public class ScoreCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        private IStats _stats;
        
        [Inject]
        private void Construct(IStats stats)
        {
            _stats = stats;
        }

        private void OnEnable()
        {
            _stats.Updated += UpdateScoreText;
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _stats.Score.ToString();
        }
        
        private void OnDisable()
        {
            _stats.Updated -= UpdateScoreText;
        }
    }
}