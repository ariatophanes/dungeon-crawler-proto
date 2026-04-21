using CharacterComponents;
using Input;
using UnityEngine;

namespace Spawn.Player
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer(
            PlayerSettings playerSettings,
            Components components,
            IInputProvider inputProvider,
            Vector2 startPos);
    }
}