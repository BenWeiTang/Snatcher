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
            CurrentStamina = MaxStamina;
            _index = 0;
            _inventory = new List<ALimb>();

            _inventory.Add(new BasicLimb());
        }
    }
}