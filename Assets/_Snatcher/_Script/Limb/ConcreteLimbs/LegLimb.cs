using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class LegLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Leg;
        public override string Name => "Leg";
        public override ASuperState SuperState => PlayerStateFactoryManager.Instance.LegState;
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        //public override float Durability { get; protected set; }
        //public override float MaxDurability { get; protected set; }
        public override float Weight { get; protected set; } = 3f;
        public override float StaminaCost { get; } = 15f;

        public LegLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}