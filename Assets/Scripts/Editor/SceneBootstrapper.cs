using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public class SceneBootstrapper
    {
        private const string BootstrapScenePath = "Assets/Scenes/Bootstrap.unity";

        static SceneBootstrapper()
        {
            var bootstrapScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(BootstrapScenePath);
            if (bootstrapScene)
            {
                EditorSceneManager.playModeStartScene = bootstrapScene;
                Debug.Log($"<color=green>Bootstrap Scene set to: {BootstrapScenePath}</color>");
            }
            else
            {
                Debug.LogError($"Bootstrap scene not found at: {BootstrapScenePath}");
            }
        }
    }
}