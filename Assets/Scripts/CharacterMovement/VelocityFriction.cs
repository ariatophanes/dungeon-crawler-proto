using UnityEngine;

namespace CharacterMovement
{
    public class VelocityFriction : IVelocityModifier
    {
        private readonly float _moveFriction;
        private readonly float _stopFriction;
        private readonly float _turnFriction;

        public VelocityFriction(float moveFriction, float stopFriction, float turnFriction)
        {
            _moveFriction = moveFriction;
            _stopFriction = stopFriction;
            _turnFriction = turnFriction;
        }

        public Vector2 Apply(Vector2 velocity, Vector2 input, float deltaTime)
        {
            var friction = SelectFriction(velocity, input);
            return velocity * Mathf.Pow(friction, deltaTime);
        }

        private float SelectFriction(Vector2 velocity, Vector2 input)
        {
            if (input.sqrMagnitude < 0.01f) return _stopFriction;

            var dot = Vector2.Dot(velocity.normalized, input.normalized);
            return dot < 0 ? _turnFriction : _moveFriction;
        }
    }
}