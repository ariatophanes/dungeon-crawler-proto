using System.Collections.Generic;
using Movement;

namespace CharacterMovement
{
    public class CharacterMovementFactory
    {
        public CharMovement Create(IMovementSettings s)
        {
            var modifiers = new List<IVelocityModifier>
            {
                new VelocityFriction(s.MoveFriction, s.StopFriction, s.TurnFriction),
                new VelocityAccelerator(s.Acceleration),
                new SpeedLimiter(s.MaxSpeed),
            };

            return new CharMovement(modifiers);
        }
    }
}