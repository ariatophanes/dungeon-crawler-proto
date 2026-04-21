using UnityEngine;

namespace CharacterComponents.Physics
{
    public interface ICharacterRigidbodyFactory
    {
        public Rigidbody2D Create(GameObject go);
    }
}