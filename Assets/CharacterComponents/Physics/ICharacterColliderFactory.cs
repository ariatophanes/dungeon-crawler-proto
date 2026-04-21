using UnityEngine;

namespace CharacterComponents.Physics
{
    public interface ICharacterColliderFactory
    {
        public Collider2D Create(GameObject go);
    }
}