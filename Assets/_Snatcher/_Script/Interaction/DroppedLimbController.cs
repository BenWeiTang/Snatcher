using UnityEngine;

namespace Snatcher
{
    public class DroppedLimbController : MonoBehaviour, IInteractable
    {
        [SerializeField] private LimbType _type;
        public void Interact()
        {
            LimbManager.Instance.TryAddLimb(_type);
            Destroy(gameObject);
        }
    }
}
