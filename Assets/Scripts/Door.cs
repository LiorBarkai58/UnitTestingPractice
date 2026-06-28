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

        private IEnumerator loadScenes()
        {
            yield return SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Level1");
        }
    }
}