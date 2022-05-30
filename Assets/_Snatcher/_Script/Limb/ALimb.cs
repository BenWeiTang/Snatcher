using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    public abstract class ALimb
    {
        /// <summary>
        /// The prefab of the Limb
        /// </summary>
        public abstract GameObject Model { get; }
        
        /// <summary>
        /// The type of the Limb Ability
        /// </summary>
        public abstract LimbType Type { get; }
        
        /// <summary>
        /// The name of the Limb Ability
        /// </summary>
        public abstract string Name { get; }
        
        /// <summary>
        /// The Super State that is associated with this Limb Ability
        /// </summary>
        public abstract ASuperState SuperState { get; }
        
        /// <summary>
        /// A list of Upgrades that have been applied to this Limb Ability.
        /// </summary>
        public abstract List<AUpgrade> Upgrades { get; protected set; }

        public abstract float Weight { get; protected set; }
        
       /// <summary>
       /// The amount of decrement every time the Durability decreases.
       /// </summary>
       public abstract float StaminaCost { get; } 

        
       protected ALimb() { }
    }
}