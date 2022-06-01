using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class LoseScript : MonoBehaviour
    {
        [SerializeField] private IntReference _snatcherLastScene;
        public void Retry()
        {
            SceneManager.LoadScene(_snatcherLastScene.Value);
        }

        public void MainMenu()
        {
            SceneManager.LoadSceneAsync((int)SceneIndex.MainMenu);
        }
    }
}
