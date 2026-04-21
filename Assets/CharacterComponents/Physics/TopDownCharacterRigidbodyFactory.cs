using UnityEngine;

namespace CharacterComponents.Physics
{
    public class TopDownCharacterRigidbodyFactory : ICharacterRigidbodyFactory
    {
        public Rigidbody2D Create(GameObject go)
        {
            var rb =  go.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.interpolation = RigidbodyInterpolation2D.Interpolate;
            rb.linearDamping = 0;
            return rb;
        }
    }
}