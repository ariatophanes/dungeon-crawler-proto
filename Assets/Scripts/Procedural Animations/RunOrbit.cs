using UnityEngine;
using UnityEngine.Serialization;

namespace Procedural_Animations
{
    public class RunOrbit : MonoBehaviour
    {
        public float rx = 0.1f;
        public float ry = 0.1f;
        [Range(0f, 1f)]
        public float pinch = 0.1f;
        public float speed = 2f;
        public float idleTransitionSpeed = 10f;

        private float _pingT = 0f;
        private int _dir = 1;
        public float intensity = 0f; // 0 = idle, 1 = full run

        public bool isRunning = false;

        private void Update()
        {
            var targetIntensity = isRunning ? 1f : 0f;
            intensity = Mathf.Lerp(intensity, targetIntensity, idleTransitionSpeed * Time.deltaTime);

            if (isRunning)
            {
                _pingT += _dir * speed * Time.deltaTime;
                if (_pingT >= 1f) { _pingT = 1f; _dir = -1; }
                if (_pingT <= 0f) { _pingT = 0f; _dir =  1; }
            }

            var angle = _pingT * Mathf.PI;
            var rawX = -Mathf.Cos(angle);
            var rawY =  Mathf.Sin(angle);
            var xScale = Mathf.Lerp(1f - pinch, 1f, rawY);

            transform.localPosition = new Vector3(
                rawX * rx * xScale * intensity,
                rawY * ry * intensity,
                0f
            );

            var tiltAngle = -rawX * xScale * 5f * intensity;
            transform.localRotation = Quaternion.Euler(0f, 0f, tiltAngle);

            var squash = (1f - rawY) * intensity;
            transform.localScale = new Vector3(
                1f + squash * 0.08f,
                1f - squash * 0.05f,
                1f
            );
        }
    }
}