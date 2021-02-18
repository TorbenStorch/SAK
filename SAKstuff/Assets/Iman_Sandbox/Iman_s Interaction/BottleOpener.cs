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
    private GameObject audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BottleOpener")
        {
            audioManager.GetComponent<AudioManager>().Play("Bottle");
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = null;
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
