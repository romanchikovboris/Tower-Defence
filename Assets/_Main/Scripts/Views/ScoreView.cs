using TMPro;
using UnityEngine;
using Zenject;

namespace _Main.Scripts.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreLabel;
        private ScoreCounter scoreCounter;

        [Inject]
        void Construct(ScoreCounter scoreCounter)
        {
            this.scoreCounter = scoreCounter;
            scoreCounter.ScoreChanged += ScoreCounterOnScoreChanged;
            ScoreCounterOnScoreChanged(scoreCounter.CurrentScore);
        }

        private void ScoreCounterOnScoreChanged(int score)
        {
            scoreLabel.text = $"Score: {score}";
        }
    }
}