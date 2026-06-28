using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private string UISceneName = "UI";
        [SerializeField] private string levelSceneName = "Level1";
        [SerializeField] private string menuSceneName = "MainMenu";

        public void LoadGame()
        {
            StartCoroutine(loadScenes());   

        }

        private IEnumerator loadScenes()
        {
            yield return SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(menuSceneName);
            yield return SceneManager.LoadSceneAsync(UISceneName, LoadSceneMode.Additive);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}