using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class WingLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Wing;
        public override string Name => "Wing";
        public override ASuperState SuperState => PlayerStateFactoryManager.Instance.WingState;
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        //public override float Durability { get; protected set; }
        //public override float MaxDurability { get; protected set; }
        public override float StaminaCost { get; } = 10f;
        public WingLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}