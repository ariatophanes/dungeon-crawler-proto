using CharacterMovement;
using Input;
using UnityEngine;

namespace PlayerFSM.States
{
    public class CharacterRunState : ICharacterState
    {
        private readonly ICharacterMovement _movement;
        private readonly IInputProvider _input;
        private ICharacterState _idle;

        public CharacterRunState(ICharacterMovement movement, IInputProvider input)
        {
            _movement = movement;
            _input = input;
        }

        public void SetTransitions(ICharacterState idle) => _idle = idle;

        public void Enter()
        {
            Debug.Log("Entered run state");
        }
        public void Exit()  { }

        public ICharacterState Tick(float dt)
        {
            var input = _input.MovementInput;
            _movement.Tick(input, dt);

            return input.sqrMagnitude < 0.01f ? _idle : null;
        }
    }
}