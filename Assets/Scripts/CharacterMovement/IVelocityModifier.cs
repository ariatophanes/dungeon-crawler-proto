using UnityEngine;

namespace CharacterMovement
{
    public interface IVelocityModifier
    {
        Vector2 Apply(Vector2 velocity, Vector2 input, float deltaTime);
    }
}