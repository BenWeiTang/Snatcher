using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/Limb Manager", fileName = "LimbManager")]
    public class LimbManager : ASingletonScriptableObject<LimbManager>
    {
        public ALimb CurrentLimb { get; private set; }

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

        [SerializeField] private VoidEvent _onLimbSwitched;
        private List<ALimb> _inventory;
        private int _index;

        public void SwitchLimb(bool forward)
        {
            if (forward)
            {
                _index++;
                _index = Mathf.Min(_index, _inventory.Count - 1);
            }
            else
            {
                _index--;
                _index = Mathf.Max(_index, 0);
            }
            ALimb priorLimb = CurrentLimb;
            CurrentLimb = _inventory[_index];
            if (CurrentLimb.Equals(priorLimb))
            {
                return;
            }
            _onLimbSwitched.Raise();
        }

        protected override void OnInitialized()
        {
            _index = 0;
            _inventory = new List<ALimb>();
            CurrentLimb = new BasicLimb();

            _inventory.Add(CurrentLimb);
            _inventory.Add(new InvisLimb());
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