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
        public float MaxStamina { get; } = 100f;
        public float CurrentStamina { get; private set; }
        public Dictionary<string, float> WeightMods { get; private set; } = new Dictionary<string, float>
        {
            {"Very Heavy", .5f},
            {"Heavy", .66f},
            {"Medium", .75f },
            {"Lightweight", 1f}
        };

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

        public bool EatLimbStaminaCost()
        {
            if(CurrentStamina > CurrentLimb.StaminaCost)
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

        public void DropActiveLimb()
        {
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
        }

        protected override void OnInitialized()
        {
            CurrentStamina = MaxStamina;
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

        public float GetInventoryWeight()
        {
            float net_weight = 0f;
            foreach(ALimb limb in _inventory)
            {
                net_weight += limb.Weight;
            }
            return net_weight;
        }

        public float GetWeightConsequenceModifier()
        {
            float net_weight = GetInventoryWeight();
            if (net_weight > 0f && net_weight < 10f)
            {
                return WeightMods["Lightweight"];
            }
            else if (net_weight < 20f)
            {
                return WeightMods["Medium"];
            }
            else if (net_weight < 30f)
            {
                return WeightMods["Heavy"];
            }
            else
            {
                return WeightMods["Very Heavy"];
            }
        }
    }
}