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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SAK")
        {
            Debug.Log("SAK toched");
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
