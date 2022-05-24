using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class PropellerLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Propeller;
        public override string Name => "Propeller";
        public override ASuperState SuperState => PlayerStateFactoryManager.Instance.PropellerState;
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        //public override float Durability { get; protected set; }
        //public override float MaxDurability { get; protected set; }
        public override float StaminaCost { get; } = 20f;
        public PropellerLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}