using CharacterMovement;
using Input;
using UnityEngine;

namespace PlayerFSM.States
{
    public class CharacterIdleState : ICharacterState
    {
        private readonly ICharacterMovement _movement;
        private readonly IInputProvider _inputProvider;
        private ICharacterState _run;

        public CharacterIdleState(ICharacterMovement movement, IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
            _movement = movement;
        }

        public void SetTransitions(ICharacterState run) => _run = run;

        public void Enter()
        {
            Debug.Log("Entered idle state");
        }

        public void Exit()  { }

        public ICharacterState Tick(float dt)
        {
            _movement.Tick(Vector2.zero, dt);
            return _inputProvider.MovementInput.sqrMagnitude > 0.01f ? _run : null;
        }
    }
}