using UnityEngine;
namespace Snatcher
{
    public class BasicLimb : ALimb
    {
        //talk to ben about the best way to do this
        public GameObject model = (GameObject)Resources.Load("Assets/_Snatcher/Prefab/Player", typeof(GameObject));
        public override LimbType Type => LimbType.Basic;


        private string name = "basic";
        private float durability = float.PositiveInfinity;
        public BasicLimb() : base()
        {
        }
    }
}