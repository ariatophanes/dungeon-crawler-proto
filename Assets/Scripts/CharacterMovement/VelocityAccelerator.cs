using UnityEngine;

namespace CharacterMovement
{
    public class VelocityAccelerator : IVelocityModifier
    {
        private readonly float _acceleration;

        public VelocityAccelerator(float acceleration) =>
            _acceleration = acceleration;

        public Vector2 Apply(Vector2 velocity, Vector2 input, float deltaTime) =>
            velocity + input * _acceleration * deltaTime;
    }
}