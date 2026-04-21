using CharacterComponents;
using CharacterMovement;
using Input;
using UnityEngine;

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
            components.SpriteRendererFactory.Create(go, playerSettings.Sprite);

            var characterMovement = new CharacterMovementFactory().Create(playerSettings.MovementSettings, startPos);
            var characterMover = go.AddComponent<CharacterMover>();

            characterMover.Initialize(characterMovement, inputProvider, rb);
            return go;
        }
    }
}