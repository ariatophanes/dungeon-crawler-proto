using System.Collections.Generic;
using Movement;
using UnityEngine;

namespace CharacterMovement
{
    public class CharacterMovementFactory
    {
        public CharMovement Create(IMovementSettings s, Vector2 startPosition)
        {
            var modifiers = new List<IVelocityModifier>
            {
                new VelocityFriction(s.MoveFriction, s.StopFriction, s.TurnFriction),
                new VelocityAccelerator(s.Acceleration),
                new SpeedLimiter(s.MaxSpeed),
            };

            return new CharMovement(modifiers, startPosition);
        }
    }
}