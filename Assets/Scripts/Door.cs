using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Door : MonoBehaviour
    {
        private readonly string playerTag = "Player";
        [SerializeField] private bool shouldMoveScene = false;
        [SerializeField] private string SceneToLoad;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                StartCoroutine(loadScenes());
            }
        }

        /// <summary>
        /// This would of course be changed to a proper scene transition manager
        /// that holds the reference to the current scene and unloads it properly
        /// but for the sake of this project we unload it with strings
        /// </summary>
        /// <returns></returns>
        private IEnumerator loadScenes()
        {
            yield return SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Level1");
        }
    }
}