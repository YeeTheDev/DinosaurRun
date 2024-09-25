using System;
using UnityEngine;
using DinoRun.Controls;

namespace DinoRun.Scores
{
    public class Score : MonoBehaviour
    {
        public Action<int> OnScoreIncrease;

        [Min(0)] [SerializeField] float timeToIncrease;
        [SerializeField] int pointPerTime;
        [SerializeField] GameObject gameOverPanel;

        int score;
        float timer;
        Character character;

        public void SetEvent(Character character)
        {
            this.character = character;
            character.OnGameOver += SaveHiScore;
            timer = Time.time + timeToIncrease;
        }

        private void Update()
        {
            if (Time.time > timer)
            {
                timer = Time.time + timeToIncrease;
                score += pointPerTime;

                OnScoreIncrease!.Invoke(score);
            }
        }

        private void SaveHiScore()
        {
            if (PlayerPrefs.GetInt("HiScore") < score) { PlayerPrefs.SetInt("HiScore", score); }

            gameOverPanel.SetActive(true);
        }
    }
}