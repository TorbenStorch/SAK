using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private void Start()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Saw")
        {
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }*/
}
