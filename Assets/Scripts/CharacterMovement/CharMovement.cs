using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CharacterMovement
{
    public class CharMovement : ICharacterMovement
    {
        private readonly IReadOnlyList<IVelocityModifier> _modifiers;
        public Vector2 Velocity { get; private set; }
        public CharMovement(IReadOnlyList<IVelocityModifier> modifiers) => _modifiers = modifiers;
        
        public void Tick(Vector2 input, float deltaTime)
        {
            Velocity = _modifiers.Aggregate(Velocity,
                (v, mod) => mod.Apply(v, input, deltaTime));
        }
        public void SetVelocity(Vector2 v) => Velocity = v;
    }
}