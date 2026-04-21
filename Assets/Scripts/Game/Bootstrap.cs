using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LoadLevel("Level_001"));
        }

        private IEnumerator LoadLevel(string levelName)
        {
            var op = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
            yield return op;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
        }
    }
}