using UnityEngine;

namespace DinoRun.Core
{
    public class SpeedHandler : MonoBehaviour
    {
        public static float globalSpeed;

        [SerializeField] float startingSpeed = 0.2f;
        [SerializeField] float speedPerSecond;
        [SerializeField] float maxSpeed = 10f;

        float timer = 1;
        float debug;

        private void Awake() => globalSpeed = startingSpeed;

        private void Update()
        {
            if (globalSpeed < maxSpeed && Time.timeSinceLevelLoad >= timer)
            {
                timer = Time.timeSinceLevelLoad + 1;
                globalSpeed = Mathf.Clamp(globalSpeed + speedPerSecond, startingSpeed, maxSpeed);
                debug = globalSpeed;
            }
        }
    }
}