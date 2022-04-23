using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class Basic : ALimb
    {
        public override LimbType Type => LimbType.Basic;
        private string name = "basic";
        private float durability = float.PositiveInfinity;
        public Basic() : base()
        {
        }
    }
}
