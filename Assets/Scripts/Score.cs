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

        int score;
        float timer;
        Character character;

        private void Awake()
        {
            timer = Time.time + timeToIncrease;
            character = FindAnyObjectByType<Character>();
        }

        private void OnEnable() => character.OnGameOver += SaveHiScore;
        private void OnDisable() => character.OnGameOver -= SaveHiScore;

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
        }
    }
}