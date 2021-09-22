using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace _Main.Scripts.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI scoreLabel;
        [SerializeField] private Button restartButton;
        
        private FinishTrigger finishTrigger;
        private ScoreCounter scoreCounter;
        
        [Inject]
        void Construct(FinishTrigger finishTrigger, ScoreCounter scoreCounter)
        {
            this.finishTrigger = finishTrigger;
            this.scoreCounter = scoreCounter;

            finishTrigger.GameOver += ShowUI; 
        }

        private void ShowUI()
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            scoreLabel.text = $"Your score: {scoreCounter.CurrentScore.ToString()}";
            restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}