using UnityEngine;
using DinoRun.Core;

namespace DinoRun.VisualEffects
{
    public class Parallax : MonoBehaviour
    {
        Material material;

        private void Awake() => material = GetComponent<SpriteRenderer>().material;

        private void FixedUpdate()
        {
            Vector2 offset = Vector3.right * SpeedHandler.globalSpeed * Time.fixedDeltaTime;
            material.mainTextureOffset += offset;
        }
    }
}