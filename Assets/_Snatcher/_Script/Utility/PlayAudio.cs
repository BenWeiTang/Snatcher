using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class PlayAudio : MonoBehaviour
    {
        [SerializeField] private GameObject audioObject;
        // Start is called before the first frame update
        void Start()
        {
            audioObject.GetComponent<AudioSource>().Play();
        }

        private void play()
        {
            audioObject.GetComponent<AudioSource>().Play();
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
