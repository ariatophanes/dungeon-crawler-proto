using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class PlayerInputProvider : MonoBehaviour, IInputProvider
    {
        [SerializeField] private InputActionAsset inputActions;

        private InputAction _moveAction;
        private InputAction _attackAction;

        private void Awake()
        {
            var playerMap = inputActions.FindActionMap("Player", throwIfNotFound: true);
            _moveAction   = playerMap.FindAction("Move",   throwIfNotFound: true);
            _attackAction = playerMap.FindAction("Attack", throwIfNotFound: true);
        }

        private void OnEnable()
        {
            _moveAction.Enable();
            _attackAction.Enable();
        }

        private void OnDisable()
        {
            _moveAction.Disable();
            _attackAction.Disable();
        }

        public Vector2 MovementInput => _moveAction.ReadValue<Vector2>();
        public bool AttackInput      => _attackAction.WasPressedThisFrame();
    }
}
