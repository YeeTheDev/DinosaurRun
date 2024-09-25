using UnityEngine;
using DinoRun.Core;
using Random = UnityEngine.Random;

namespace DinoRun.Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] float spawnRate = 2.5f;
        [SerializeField] float spawnRandomizer = 0.25f;
        [SerializeField] float decreaseMultiplier = 0.2f;
        [SerializeField] GameObject spawnableObjects;

        float timer;

        private void Awake() => timer = spawnRate;

        private void Update()
        {
            if (Time.timeSinceLevelLoad >= timer)
            {
                float spawnTime = spawnRate + Random.Range(-spawnRandomizer, spawnRandomizer)
                    - SpeedHandler.globalSpeed * decreaseMultiplier;
                timer = Time.timeSinceLevelLoad + spawnTime;
                Instantiate(spawnableObjects, transform.position, Quaternion.identity);
            }
        }
    }
}
