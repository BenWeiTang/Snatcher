using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/Limb Manager", fileName = "LimbManager")]
    public class LimbManager : ASingletonScriptableObject<LimbManager>
    {
        public LimbType CurrentType { get; private set; } = LimbType.Basic;
        public ALimb CurrentLimb { get; private set; }

        [SerializeField] private VoidEvent _onLimbSwitched;
        
        private List<ALimb> _inventory;
        private int _index;

        public void SwitchLimb()
        {
            _index++;
            _index %= _inventory.Count;
            CurrentLimb = _inventory[_index];
            CurrentType = CurrentLimb.Type;
            _onLimbSwitched.Raise();
        }

        protected override void OnInitialized()
        {
            _index = 0;
            _inventory = new List<ALimb>();
            _inventory.Add(new BasicLimb());
        }

        public ALimb PriorLimb()
        {
            if (_index != 0)
            {
                return _inventory[_index - 1];
            }
            else return null;
        }

        public ALimb NextLimb()
        {
            if (_index != _inventory.Count-1)
            {
                return _inventory[_index + 1];
            }
            else return null;
        }
    }
}
