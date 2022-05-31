using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class FootstepAudio : MonoBehaviour
    {
        [SerializeField] private PlayerStateReference _currentPlayerSubState;
        public AudioSource footstepAudio;
        public APlayerState subState;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
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
