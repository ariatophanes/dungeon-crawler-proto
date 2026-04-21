using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "Settings/Controls/MovementSettings", order = 0)]
    public class MovementSettings : ScriptableObject, IMovementSettings
    {
        [field: SerializeField] public float MaxSpeed    { get; private set; } = 5f;
        [field: SerializeField] public float Acceleration { get; private set; } = 18f;
        [field: SerializeField] public float MoveFriction    { get; private set; } = 0.1f;
        [field: SerializeField] public float StopFriction    { get; private set; } = 0.01f;
        [field: SerializeField] public float TurnFriction    { get; private set; } = 0.05f;
        

    }
}