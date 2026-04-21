using Movement;
using UnityEngine;

namespace Spawn.Player
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/PlayerSettings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public MovementSettings MovementSettings { get; private set; }
    }
}