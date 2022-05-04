using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private BoolReference _hasKey;
        public void Reset() {
            _hasKey.Value = false;
        }
    }
}
