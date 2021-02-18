/// P3 Swiss Army Knife project
/// All
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleOpener : MonoBehaviour
{
    [HideInInspector]
    public bool bottleOpened = false;

    private string sakTag = "BottleOpener";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BottleOpener")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
                if(bottleOpened == false)
                {
                    bottleOpened = true;
                }
            }
        }
    } 
}
