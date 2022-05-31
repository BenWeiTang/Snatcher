using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public class BasicLimb : ALimb
    {
        public sealed override GameObject Model => Resources.Load<GameObject>($"Limb/{GetType().ToString().Substring(9)}");
        public override LimbType Type => LimbType.Basic;
        public override string Name => "Hook";
        public override ASuperState SuperState => PlayerStateFactoryManager.Instance.BasicState;
        public sealed override List<AUpgrade> Upgrades { get; protected set; }
        //public override float Durability { get; protected set; } = 100f;
        //public override float MaxDurability { get; protected set; } = 100f;
        public override float Weight { get; protected set; } = 1f;
        public override float StaminaCost { get; } = 5f;

        public BasicLimb() : base()
        {
            Upgrades = new List<AUpgrade>();
        }
    }
}
