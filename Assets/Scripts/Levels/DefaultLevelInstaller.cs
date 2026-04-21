using CharacterComponents;
using CharacterComponents.Physics;
using CharacterComponents.Rendering;
using Input;
using Spawn.Player;
using UnityEngine;

namespace Levels
{
    public class DefaultLevelInstaller : MonoBehaviour, ILevelInstaller
    {
        [SerializeField] private PlayerInputProvider playerInputProvider;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform[] enemySpawnPoints;

        private void Start()
        {
            Install();
        }

        public void Install()
        {
            var defaultCharComponents = new Components(
                new TopDownCharacterRigidbodyFactory(),
                new CapsuleCharacterColliderFactory(),
                new CharacterSpriteRendererFactory());

            InstallPlayer(defaultCharComponents);
            InstallEnemies();
        }

        private void InstallPlayer(Components components)
        {
            var player = new PlayerFactory().CreatePlayer(playerSettings,
                components, 
                playerInputProvider,
                playerSpawnPoint.position);
        }

        private void InstallEnemies()
        {
            // TODO: Install Enemies Logic
        }
    }
}