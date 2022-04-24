using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snatcher
{
    public class ActiveLimbDisplay : MonoBehaviour
    {
        [SerializeField] public GameObject currentLimbDisplay;
        [SerializeField] public GameObject priorLimbDisplay;
        [SerializeField] public GameObject nextLimbDisplay;

        private Text currentLimbDisplayText;
        private Text priorLimbDisplayText;
        private Text nextLimbDisplayText;
        // Start is called before the first frame update
        void Start()
        {
            currentLimbDisplayText = currentLimbDisplay.GetComponent<Text>();
            priorLimbDisplayText = priorLimbDisplay.GetComponent<Text>();
            nextLimbDisplayText = nextLimbDisplay.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            //can uncomment once limb manager is correctly switching and equipping limbs or once limbs are attached to player
            if(LimbManager.Instance.CurrentLimb != null)
            {
                currentLimbDisplayText.text = LimbManager.Instance.CurrentLimb.getName();
            }
            else
            {
                currentLimbDisplayText.text = "";
            }
            if (LimbManager.Instance.PriorLimb() != null)
            {
                priorLimbDisplayText.text = LimbManager.Instance.PriorLimb().getName();
            } 
            else
            {
                priorLimbDisplayText.text = "";
            }
            if(LimbManager.Instance.NextLimb() != null)
            {
                nextLimbDisplayText.text = LimbManager.Instance.NextLimb().getName();
            }
            else
            {
                nextLimbDisplayText.text = "";
            }
            
        }
    }
}
