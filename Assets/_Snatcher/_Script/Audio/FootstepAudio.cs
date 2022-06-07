using UnityEngine;

namespace Snatcher
{
    public class FootstepAudio : MonoBehaviour
    {
        [SerializeField] private PlayerStateReference _currentPlayerSubState;
        public AudioSource footstepAudio;
        private void Update()
        {
            var subState = _currentPlayerSubState.Value.GetType();

            if (subState == typeof(MoveState) && !footstepAudio.isPlaying)
            {            
                footstepAudio.Play();
            }
            else if (subState != typeof(MoveState) && footstepAudio.isPlaying)
            {        
                footstepAudio.Stop();
            }
        }
    }
}
