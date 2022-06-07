using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class WindController : MonoBehaviour
    {
        [SerializeField] private CharacterController _playerController;
        [SerializeField] private float windPushSpeed;

        // Start is called before the first frame update
        void Start()
        {
        }

        void OnTriggerStay(Collider other) 
        {
            if (other.tag == "Player")
                _playerController.SimpleMove(new Vector3(-windPushSpeed, 0f, 0f));
        }
    }
}
