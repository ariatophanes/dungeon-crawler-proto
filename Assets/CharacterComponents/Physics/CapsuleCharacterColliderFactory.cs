using UnityEngine;

namespace CharacterComponents.Physics
{
    public class CapsuleCharacterColliderFactory : ICharacterColliderFactory
    {
        public Collider2D Create(GameObject go)
        {
            var col = go.AddComponent<CapsuleCollider2D>();
            col.isTrigger = false;
            col.size = new Vector2(0.85f, 1f);
            return col;
        }
    }
}