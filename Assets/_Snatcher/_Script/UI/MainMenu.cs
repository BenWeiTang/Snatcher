using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Alpha_UpperWorld");
        }

        public void PlayTutorial()
        {
            // Uncomment this when tutorial is added. This is the name Erica has in her branch.
            SceneManager.LoadScene("Demo_Overworld_Tutorial");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
