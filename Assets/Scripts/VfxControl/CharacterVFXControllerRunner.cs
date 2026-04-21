using UnityEngine;

namespace VfxControl
{
    public class CharacterVFXControllerRunner : MonoBehaviour
    {
        private CharacterVFXController _controller;

        public void Initialize(CharacterVFXController controller) => _controller = controller;

        private void Update() => _controller.Update();
    }
}