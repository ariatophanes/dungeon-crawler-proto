using System.Runtime.CompilerServices;
using PlayerFSM;
using PlayerFSM.States;
using UnityEngine;
using UnityEngine.VFX;

namespace VfxControl
{
    public class CharacterVFXController
    {
        private readonly VisualEffect _runVfx;
        private readonly Transform _t;
        private readonly Rigidbody2D _rb;

        public CharacterVFXController(VisualEffect runVfx, Rigidbody2D rigidbody)
        {
            _rb = rigidbody;
            _t = rigidbody.transform;
            _runVfx = runVfx;
        }

        public void Initialize() => _runVfx.Stop();

        public void Update()
        {
            _runVfx.SetFloat("Speed", Mathf.Abs(_rb.linearVelocity.magnitude));
            _runVfx.SetFloat("GroundY", _t.position.y);
            _runVfx.SetVector3("MoveDirection", (Vector3)_rb.linearVelocity);
        }

        public void OnStateChanged(ICharacterState from, ICharacterState to)
        {
            switch (to)
            {
                case CharacterIdleState: _runVfx.Stop(); break;
                case CharacterRunState: _runVfx.Play(); break;
            }
        }
    }
}