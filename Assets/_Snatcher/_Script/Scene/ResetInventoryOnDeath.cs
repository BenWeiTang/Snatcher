using UnityEngine;

namespace Snatcher
{
    public class ResetInventoryOnDeath : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            LimbManager.Instance.ResetInventory();
        }
    }
}
