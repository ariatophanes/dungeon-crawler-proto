using System;
using PlayerFSM;
using PlayerFSM.States;
using Procedural_Animations;
using UnityEngine;

namespace AnimationControl
{
    public class CharacterAnimationController
    {
        private readonly SpriteRenderer _sr;
        private readonly Rigidbody2D _rb;
        private RunOrbit _runOrbitAnimation;

        public CharacterAnimationController(SpriteRenderer sr, Rigidbody2D rb)
        {
            _rb = rb;
            _sr = sr;
        }

        public void Initialize() => _runOrbitAnimation = _sr.gameObject.AddComponent<RunOrbit>();

        public void Update()
        {
            _runOrbitAnimation.speed = Mathf.Max(_rb.linearVelocity.magnitude, 
                _runOrbitAnimation.intensity * 2f);
        }
        public void OnStateChanged(ICharacterState from, ICharacterState to)
        {
            switch (to)
            {
                case CharacterIdleState: _runOrbitAnimation.isRunning = false;      break;
                case CharacterRunState: _runOrbitAnimation.isRunning = true;     break;
            }
        }
    }
}