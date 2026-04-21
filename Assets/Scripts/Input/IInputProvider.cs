using UnityEngine;

namespace Input
{
    public interface IInputProvider
    {
        public Vector2 MovementInput { get; }
        public bool AttackInput { get; }
    }
}