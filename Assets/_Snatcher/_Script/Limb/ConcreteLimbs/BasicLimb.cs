using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class BasicLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Basic;
        public override string Name => "Basic";
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        public override float Durability { get; protected set; } = float.PositiveInfinity;
        public override float MaxDurability { get; protected set; } = float.PositiveInfinity;
        protected override float DecrementDelta { get; set; } = 0f;
        protected override ASuperState SuperState { get; }

        public BasicLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}
