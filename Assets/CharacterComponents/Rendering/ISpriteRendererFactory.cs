using UnityEngine;

namespace CharacterComponents.Rendering
{
    public interface ISpriteRendererFactory
    {
        SpriteRenderer Create(GameObject go, Sprite sprite, Sprite shadowSprite);
    }
}