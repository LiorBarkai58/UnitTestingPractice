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
        /// <summary>
        /// This would of course be changed to a proper scene transition manager
        /// that holds the reference to the current scene and unloads it properly
        /// but for the sake of this project we unload it with strings
        /// </summary>
        /// <returns></returns>
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