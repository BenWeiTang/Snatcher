using System.Collections.Generic;
using UnityEngine;

namespace Snatcher
{
    [CreateAssetMenu(menuName = "Snatcher/Manager/Limb Manager", fileName = "LimbManager")]
    public class LimbManager : ASingletonScriptableObject<LimbManager>
    {
<<<<<<< HEAD
        public ALimb CurrentLimb { get; private set; }
        
        [SerializeField] private VoidEvent _onAbilityUsed;

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
=======
        public ALimb CurrentLimb => _inventory[_index];
        public float MaxStamina { get; } = 100f;
        public float CurrentStamina { get; private set; }
        public ALimb NextLimb => _index == _inventory.Count - 1 ? null : _inventory[_index + 1];
        public ALimb PriorLimb => _index == 0 ? null : _inventory[_index - 1];
        public LimbType CurrentType => CurrentLimb.Type;
        public float InventoryWeight => _inventory.Sum(limb => limb.Weight);
        public float WeightConsequenceModifier => InventoryWeight switch
        {
            > 0f and < 10f => 1f,
            < 20f => .75f,
            < 30f => .66f,
            _ => .5f
        };

        public event Action<LimbType> OnLimbForcedSwitched;
>>>>>>> dev

        [SerializeField] private VoidEvent _onLimbSwitched;
        private List<ALimb> _inventory;
        private int _index;

        public void SwitchLimb(bool forward)
        {
            if (forward)
            {
<<<<<<< HEAD
=======
                if (_index == _inventory.Count - 1)
                    return;

>>>>>>> dev
                _index++;
                _index = Mathf.Min(_index, _inventory.Count - 1);
            }
            else
            {
<<<<<<< HEAD
=======
                if (_index == 0)
                    return;

>>>>>>> dev
                _index--;
                _index = Mathf.Max(_index, 0);
            }
<<<<<<< HEAD
            ALimb priorLimb = CurrentLimb;
            CurrentLimb = _inventory[_index];
            if (CurrentLimb.Equals(priorLimb))
            {
                return;
            }
=======

            _onLimbSwitched.Raise();
        }

        public bool EatLimbStaminaCost()
        {
            if (CurrentStamina > CurrentLimb.StaminaCost)
            {
                CurrentStamina -= CurrentLimb.StaminaCost;
                _onAbilityUsed.Raise();
                return true;
            }
            else
            {
                //_insufficientStaminaForLimb.Raise();
                return false;
            }
        }

        public void TryAddLimb(LimbType type)
        {
            if (_inventory.Any(item => item.Type == type))
                return;

            ALimb limbToAdd = type switch
            {
                LimbType.Invis => new InvisLimb(),
                LimbType.Leg => new LegLimb(),
                LimbType.Wing => new WingLimb(),
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
>>>>>>> dev
            _onLimbSwitched.Raise();
        }

        public void DecrementLimbDurability()
        {
<<<<<<< HEAD
            CurrentLimb.DecrementDurability();
            _onAbilityUsed.Raise();
=======
            // Shouldn't drop basic limb
            if (_index == 0)
                return;

            Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
            playerPosition.y -= 0.05f;
            var go = Instantiate(CurrentLimb.Model, playerPosition, Quaternion.identity);

            _inventory.Remove(CurrentLimb);
            _index--;
            OnLimbForcedSwitched?.Invoke(CurrentType);
            _onLimbSwitched.Raise();
        }

        public void ResetInventory()
        {
            _inventory.Clear();
            _inventory.Add(new BasicLimb());
            _index = 0;
>>>>>>> dev
        }

        public void RecoverStamina(float amount)
        {
            CurrentStamina += amount;
            if (amount < 0)
            {
                CurrentStamina = Mathf.Max(0f, CurrentStamina);
            }
            else
            {
                CurrentStamina = Mathf.Min(100f, CurrentStamina);
            }
        }

        protected override void OnInitialized()
        {
            _index = 0;
            _inventory = new List<ALimb>();
            CurrentLimb = new BasicLimb();

            _inventory.Add(CurrentLimb);
            _inventory.Add(new InvisLimb());
        }
<<<<<<< HEAD

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
=======
>>>>>>> dev
    }
}