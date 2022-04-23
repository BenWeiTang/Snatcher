using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/Limb Manager", fileName = "LimbManager")]
    public class LimbManager : ASingletonScriptableObject<LimbManager>
    {
        public LimbType CurrentEquippedLimb { get; private set; } = LimbType.Basic;

        private List<ALimb> _inventory;

        protected override void OnInitialized()
        {
            _inventory = new List<ALimb>();
            //_inventory[LimbType.Basic] = 
        }
    }
}
