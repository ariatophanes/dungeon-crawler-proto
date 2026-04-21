using UnityEngine;

namespace CharacterComponents.Rendering
{
    public class CharacterSpriteRendererFactory : ISpriteRendererFactory
    {
        public SpriteRenderer Create(GameObject go, Sprite sprite)
        {
            var sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            return sr;
        }
    }
}