using UnityEngine;
using DinoRun.Scores;
using DinoRun.Controls;
using UnityEngine.SceneManagement;

namespace DinoRun.UI
{
    public class CharacterCreator : MonoBehaviour
    {
        [SerializeField] Score score;

        private void Awake() => Time.timeScale = 0;

        public void CreateCharacter(Character character)
        {
            Character createdCharacter = Instantiate(character);

            Time.timeScale = 1;

            score.SetEvent(createdCharacter);
        }

        public void ReloadScene() => SceneManager.LoadScene(0);
    }
}