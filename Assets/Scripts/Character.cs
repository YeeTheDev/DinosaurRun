using UnityEngine;

namespace DinoRun.Controls
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] float jumpHeight;
        [SerializeField] string floorTag = "Floor";

        bool canJump;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.sleepThreshold = 0;
        }

        private void Update() => TryJump();

        private void TryJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.velocity = Vector3.up * Mathf.Sqrt(jumpHeight * 2 * Physics.gravity.y * -1);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag(floorTag)) { canJump = true; }
            else { Time.timeScale = 0; }
        }

        private void OnCollisionExit(Collision collision) => canJump = false;
    }
}