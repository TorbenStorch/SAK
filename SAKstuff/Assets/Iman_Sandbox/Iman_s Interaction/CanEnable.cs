/// P3 Swiss Army Knife project
/// Iman, Torben
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEnable : MonoBehaviour
{
    public GameObject canOpen;
    public GameObject canClose;
    private string sakTag = "CanOpener";

    [HideInInspector]
    public bool canOpened = false;
    private GameObject audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    void Start()
    {
        canClose.SetActive(true);
        canOpen.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(sakTag))
        {
            // Play audio
            audioManager.GetComponent<AudioManager>().Play("Can");
            // Make it "reactable"
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            // Exchange can
            canOpen.SetActive(true);
            canClose.SetActive(false);
            // For adventure
            if (canOpened == false)
            {
                canOpened = true;
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(sakTag))
        {
            audioManager.GetComponent<AudioManager>().Play("Can");
            canOpen.SetActive(true);
            canClose.SetActive(false);
            // For adventure
            if(canOpened == false)
            {
                canOpened = true;
            }
        }
    }*/
}
