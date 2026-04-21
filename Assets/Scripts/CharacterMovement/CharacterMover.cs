using System;
using Input;
using UnityEngine;

namespace CharacterMovement
{
    public class CharacterMover : MonoBehaviour
    {
        private ICharacterMovement _movement;
        private Rigidbody2D _rb;
        private IInputProvider _inputProvider;

        public void Initialize(ICharacterMovement movement, IInputProvider inputProvider, Rigidbody2D rb)
        {
            _inputProvider = inputProvider;
            _rb = rb;
            _movement = movement;
        }

        public void FixedUpdate()
        {
            _movement.Tick(_inputProvider.MovementInput, Time.fixedDeltaTime);
            _rb.MovePosition(_movement.Position);
            // _movement.Synchronise(_rb.transform.position);
        }
    }
}