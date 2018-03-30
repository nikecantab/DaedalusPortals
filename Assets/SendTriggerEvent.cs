using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendTriggerEvent : MonoBehaviour {

    public GameObject manager;
    public bool triggered=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PuzzleCube")
        {
            if (!other.GetComponent<PickUp>().isHolding)
            {
                triggered = true;
                manager.GetComponent<TriggerPortalActivationMultiple>().OnButtonTriggered();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (triggered == false)
        {
            if (other.tag == "PuzzleCube")
            {
                if (!other.GetComponent<PickUp>().isHolding)
                {
                    triggered = true;
                    manager.GetComponent<TriggerPortalActivationMultiple>().OnButtonTriggered();
                }
            }
        }
        
    }
}
