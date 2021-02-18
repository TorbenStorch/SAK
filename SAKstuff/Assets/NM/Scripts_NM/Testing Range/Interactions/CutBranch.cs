using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for cutting movement of the branch
/// 2) There have to be two box colliders on branch - lower will be trigger:
/// 3) This script has to be connceted with branch
/// 4) On bush has to be nothing (colliders only?)
/// </summary>
public class CutBranch : MonoBehaviour
{
    [HideInInspector]
    public bool branchCut = false;
    private GameObject audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Saw")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = null;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                audioManager.GetComponent<AudioManager>().Play("Branch");
                this.GetComponent<Rigidbody>().useGravity = true;
                if (branchCut == false)
                {
                    branchCut = true;
                }
                // For adventure - campfire
                GetComponent<Interactable>().enabled = true;
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                audioManager.GetComponent<AudioManager>().Play("Branch");
                this.GetComponent<Rigidbody>().useGravity = true;
                if (branchCut == false)
                {
                    branchCut = true;
                }
            }
        }
    }*/
}
