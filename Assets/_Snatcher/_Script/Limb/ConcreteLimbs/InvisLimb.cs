using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class InvisLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Invis;
        public override string Name => "Invisibility";
        public override ASuperState SuperState => PlayerStateFactoryManager.Instance.InvisState;
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        //public override float Durability { get; protected set; }
        //public override float MaxDurability { get; protected set; }
        public override float StaminaCost { get; } = 5f;

        public InvisLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}