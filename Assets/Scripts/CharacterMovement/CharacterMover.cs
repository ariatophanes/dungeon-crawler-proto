using UnityEngine;

namespace CharacterMovement
{
    public class CharacterMover : MonoBehaviour
    {
        private ICharacterMovement _movement;
        private Rigidbody2D _rb;

        public void Initialize(ICharacterMovement movement, Rigidbody2D rb)
        {
            _movement = movement;
            _rb = rb;
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _movement.Velocity;
        }
    }
}