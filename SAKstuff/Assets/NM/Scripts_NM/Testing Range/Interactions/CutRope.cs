using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for cutting movement of the rope
/// 2) There have to be two parts of rope:
/// 3) This script has to be connceted with down part of rope
/// 4) On the down rope has to be rigidbody (uncheck - use gravity andvis kinematic) and collider (above cutting place)
/// </summary>
public class CutRope : MonoBehaviour
{
    //note from torben: needed that :)
    [HideInInspector]
    public bool ropeCut = false;
    //note end

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Knife")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {
                this.GetComponent<Rigidbody>().useGravity = true;
                if (ropeCut == false)
                {
                    ropeCut = true;
                }
            }
        }
        /*private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Knife")
            {
                ropeCut = true;
                // When gravity is switched on - down part will fall
                if (this.GetComponent<Rigidbody>().useGravity == false)
                {
                    this.GetComponent<Rigidbody>().useGravity = true;
                }
            }
       */
    }
}
