using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/Limb Manager", fileName = "LimbManager")]
    public class LimbManager : ASingletonScriptableObject<LimbManager>
    {
        public ALimb CurrentLimb => _inventory[_index];

        /// <summary>
        /// The next limb in the current limb selection rotation. Is is what should appear in the right slot of the UI. Returns null if there are less than two available limbs.
        /// </summary>
        public ALimb NextLimb
        {
            get
            {
                int nextIndex = GetNextIndex(_index, _inventory.Count);
                return nextIndex == -1 ? null : _inventory[nextIndex];
            }
        }

        /// <summary>
        /// The prior limb in the current limb selection rotation. It is what should appear in the left slot of the UI. Returns null if there are less than three available limbs.
        /// </summary>
        public ALimb PriorLimb
        {
            get
            {
                int priorIndex = GetPriorIndex(_index, _inventory.Count);
                return priorIndex == -1 ? null : _inventory[priorIndex];
            }
        }

        public LimbType CurrentType => CurrentLimb.Type;
        
        public event Action<LimbType> OnLimbForcedSwitched;

        [SerializeField] private VoidEvent _onLimbSwitched;
        [SerializeField] private VoidEvent _onAbilityUsed;
        private List<ALimb> _inventory;
        private int _index;

        public void SwitchLimb(bool forward)
        {
            if (forward)
            {
                if (_index == _inventory.Count - 1)
                    return;
                
                _index++;
            }
            else
            {
                if (_index == 0)
                    return;
                
                _index--;
            }

            _onLimbSwitched.Raise();
        }

        public void DecrementLimbDurability()
        {
            CurrentLimb.DecrementDurability();
            _onAbilityUsed.Raise();
        }

        public void TryAddLimb(LimbType type)
        {
            if (_inventory.Any(item => item.Type == type))
                return;

            ALimb limbToAdd = type switch
            {
                LimbType.Invis => new InvisLimb(),
                LimbType.Leg => new LegLimb(),
                LimbType.Propeller => new PropellerLimb(),
                //TODO: add propeller limb
                _ => null
            };

            if (limbToAdd == null)
            {
                this.LogError("Unable to identify appropriate Limb to add!");
                return;
            }
            
            // Insert Limb to front of inventory but after basic
            _inventory.Insert(1, limbToAdd);
            
            // Automatically jump to the newly snatched Limb
            _index = 1;
            
            OnLimbForcedSwitched?.Invoke(type);
            _onLimbSwitched.Raise();
        }

        protected override void OnInitialized()
        {
            _index = 0;
            _inventory = new List<ALimb>();

            _inventory.Add(new BasicLimb());
        }

        /// <summary>
        /// Returns the next index given the current index and the total count of elements in the collection. Returns -1 if total is less than 2.
        /// </summary>
        private static int GetNextIndex(int currentIndex, int total)
        {
            if (currentIndex == total - 1)
                return -1;

            return currentIndex + 1;
        }

        /// <summary>
        /// Returns the previous index given the current index and the total count of elements in the collection. Returns -1 if total is less than 3.
        /// </summary>
        private static int GetPriorIndex(int currentIndex, int total)
        {
            if (currentIndex == 0)
                return -1;

            return currentIndex - 1;
        }
    }
}