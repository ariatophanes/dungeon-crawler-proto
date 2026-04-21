using UnityEngine;

namespace CharacterComponents.Rendering
{
    public class CharacterSpriteRendererFactory : ISpriteRendererFactory
    {
        public SpriteRenderer Create(GameObject go, Sprite sprite, Sprite shadowSprite)
        {
            var srGo = new GameObject("Sprite Renderer");
            srGo.transform.SetParent(go.transform);
            var sr = srGo.AddComponent<SpriteRenderer>();
            sr.sprite = sprite;
            sr.sortingOrder = 1;
            
            var shadowSrGo = new GameObject("Shadow");
            shadowSrGo.transform.SetParent(srGo.transform, false);
            var shadowSr = shadowSrGo.AddComponent<SpriteRenderer>();
            shadowSr.sprite = shadowSprite;
            shadowSrGo.transform.localPosition = Vector2.down * 0.5f;
            
            return sr;
        }
    }
}