using UnityEngine;

namespace AnimationControl
{
    public class CharacterAnimationControllerRunner : MonoBehaviour
    {
        private CharacterAnimationController _controller;

        public void Initialize(CharacterAnimationController controller) => _controller = controller;

        private void Update() => _controller.Update();
    }
}