using UnityEngine;

namespace CharacterMovement
{
    public interface ICharacterMovement
    {
        Vector2 Velocity { get; }
        void Tick(Vector2 input, float deltaTime);
        public void SetVelocity(Vector2 v);
    }
}