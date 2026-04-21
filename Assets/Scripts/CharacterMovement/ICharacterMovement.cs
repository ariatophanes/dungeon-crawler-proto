using UnityEngine;

namespace CharacterMovement
{
    public interface ICharacterMovement
    {
        Vector2 Position { get; }
        void Tick(Vector2 input, float deltaTime);
        void Synchronise(Vector2 position);
    }
}