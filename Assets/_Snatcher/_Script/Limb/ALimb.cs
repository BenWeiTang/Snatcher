using UnityEngine;

namespace Snatcher
{
    public abstract class ALimb
    {
        //talk to ben about the best way to do this
        public GameObject model { get; }
        public abstract LimbType Type { get; }
        private string name { get; }
        private AUpgrade upgrade { get; set; }
        private float durability { get; set; }
        
        public ALimb()
        {
        }

    }
}