using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CharacterMovement
{
    public class CharMovement : ICharacterMovement
    {
        private readonly IReadOnlyList<IVelocityModifier> _modifiers;
        private Vector2 _velocity;

        public Vector2 Position { get; private set; }

        public CharMovement(IReadOnlyList<IVelocityModifier> modifiers, Vector2 startPosition)
        {
            _modifiers = modifiers;
            Position = startPosition;
        }

        public void Tick(Vector2 input, float deltaTime)
        {
            _velocity = _modifiers.Aggregate(_velocity, (v, modifier) => modifier.Apply(v, input, deltaTime));
            Position += _velocity * deltaTime;
        }

        public void Synchronise(Vector2 position) => Position = position;
    }
}