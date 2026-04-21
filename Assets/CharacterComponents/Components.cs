using CharacterComponents.Physics;
using CharacterComponents.Rendering;

namespace CharacterComponents
{
    public record Components(
        ICharacterRigidbodyFactory RigidbodyFactory,
        ICharacterColliderFactory ColliderFactory,
        ISpriteRendererFactory SpriteRendererFactory
    );
}