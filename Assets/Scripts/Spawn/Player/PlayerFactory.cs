using AnimationControl;
using CharacterComponents;
using CharacterMovement;
using FSM;
using Input;
using PlayerFSM;
using PlayerFSM.States;
using UnityEngine;
using UnityEngine.VFX;
using VfxControl;

namespace Spawn.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        public GameObject CreatePlayer(
            PlayerSettings playerSettings,
            Components components, 
            IInputProvider inputProvider,
            Vector2 startPos)
        {
            var go = new GameObject("Player");
            go.transform.position = startPos;
            
            var rb = components.RigidbodyFactory.Create(go);
            components.ColliderFactory.Create(go);
            var sr = components.SpriteRendererFactory.Create(go, playerSettings.Sprite, playerSettings.ShadowSprite);
            
            var characterMovement = new CharacterMovementFactory().Create(playerSettings.MovementSettings);
            var characterMover = go.AddComponent<CharacterMover>();

            var ctx = new PlayerContext();
            var sm = new StateMachine<ICharacterState>();
            
            var idle = new CharacterIdleState(characterMovement, inputProvider);
            var run = new CharacterRunState(characterMovement, inputProvider);
            
            idle.SetTransitions(run);
            run.SetTransitions(idle);
            sm.TransitionTo(idle);

            var animationController = new CharacterAnimationController(sr, rb);
            var animationControllerRunner = go.AddComponent<CharacterAnimationControllerRunner>();
            
            sm.OnTransition += animationController.OnStateChanged; //TODO: unsubscribe
            animationControllerRunner.Initialize(animationController);
            
            animationController.Initialize();


            //todo: move vfx crestion somewhere else
            var runVfx = Object.Instantiate(playerSettings.RunVFX, go.transform, false).GetComponent<VisualEffect>();
            runVfx.transform.position += Vector3.down * 0.15f;
            var vfxController = new CharacterVFXController(runVfx, rb);
            var vfxControllerRunner = go.AddComponent<CharacterVFXControllerRunner>();
            vfxControllerRunner.Initialize(vfxController);
            
            sm.OnTransition += vfxController.OnStateChanged; //TODO: unsubscribe
            vfxController.Initialize();
            
            var brain = go.AddComponent<PlayerBrain>();
            brain.Initialize(sm);

            characterMover.Initialize(characterMovement, rb);
            return go;
        }
    }
}