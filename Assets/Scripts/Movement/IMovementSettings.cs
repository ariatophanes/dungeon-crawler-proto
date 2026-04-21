namespace Movement
{
    public interface IMovementSettings
    {
        float MaxSpeed { get; }
        float Acceleration { get; }
        float MoveFriction { get; }
        float StopFriction { get; }
        float TurnFriction { get; }
    }
}