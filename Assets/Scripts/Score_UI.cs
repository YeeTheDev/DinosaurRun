using DinoRun.Scores;
using UnityEngine;
using UnityEngine.UI;

namespace DinoRun.UI
{
    public class Score_UI : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        [SerializeField] Text hiScoreText;
        [SerializeField] GameObject gameOverPanel;

        Score score;

        private void Awake() => score = FindAnyObjectByType<Score>();

        private void Start()
        {
            if (PlayerPrefs.GetInt("HiScore") > 0)
            {
                hiScoreText.text = "HI " + PlayerPrefs.GetInt("HiScore").ToString("D6");
            }
            else { hiScoreText.text = ""; } 
        }

        private void OnEnable() => score.OnScoreIncrease += UpdateScoreUI;
        private void OnDisable() => score.OnScoreIncrease -= UpdateScoreUI;

        private void UpdateScoreUI(int score) => scoreText.text = score.ToString("D6");
    }
}