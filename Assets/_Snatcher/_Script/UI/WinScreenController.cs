using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snatcher
{
    public class WinScreenController : MonoBehaviour
    {
        [SerializeField] private int _targetSceneIndex;
        
        public void Exit()
        {
            SceneManager.LoadSceneAsync(_targetSceneIndex);
        }
    }
}
