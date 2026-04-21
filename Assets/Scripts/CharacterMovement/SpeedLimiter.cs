using UnityEngine;

namespace CharacterMovement
{
    public class SpeedLimiter : IVelocityModifier
    {
        private readonly float _maxSpeed;

        public SpeedLimiter(float maxSpeed) => _maxSpeed = maxSpeed;

        public Vector2 Apply(Vector2 velocity, Vector2 input, float deltaTime)
        {
            var sqrMax = _maxSpeed * _maxSpeed;
            return velocity.sqrMagnitude > sqrMax
                ? velocity.normalized * _maxSpeed
                : velocity;
        }
    }
}