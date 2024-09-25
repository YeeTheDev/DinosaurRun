using UnityEngine;
using System;

namespace DinoRun.Controls
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        public Action OnGameOver;

        [SerializeField] float jumpHeight;
        [SerializeField] string floorTag = "Floor";

        bool canJump;
        Animator animator;
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            rb.sleepThreshold = 0;
        }

        private void Update() => TryJump();

        private void TryJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.velocity = Vector3.up * Mathf.Sqrt(jumpHeight * 2 * Physics.gravity.y * -1);
                animator.SetBool("Jumping", true);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag(floorTag))
            {
                canJump = true;
                animator.SetBool("Jumping", !canJump);
            }
            else
            {
                OnGameOver!.Invoke();
                Time.timeScale = 0;
            }
        }

        private void OnCollisionExit(Collision collision) => canJump = false;
    }
}