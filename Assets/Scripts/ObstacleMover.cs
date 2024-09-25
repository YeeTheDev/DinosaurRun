using DinoRun.Core;
using UnityEngine;

namespace DinoRun.Controls
{
    public class ObstacleMover : MonoBehaviour
    {
        [SerializeField] float speed = 1.5f;

        private void FixedUpdate()
        {
            if (transform.position.x < -17) { Destroy(gameObject); }

            transform.Translate(Vector3.left * SpeedHandler.globalSpeed * Time.fixedDeltaTime * speed);
        }
    }
}