using UnityEngine;
using DinoRun.Core;

public class Spawner : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 5f;
    [SerializeField] float timeBeforeSpawning = 0.5f;
    [SerializeField] int spawnChance;
    [SerializeField] GameObject[] spawnableObjects;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * SpeedHandler.globalSpeed * Time.fixedDeltaTime * speedMultiplier);
    }
}
