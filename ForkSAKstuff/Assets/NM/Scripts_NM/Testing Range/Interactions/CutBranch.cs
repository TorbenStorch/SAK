﻿using System.Collections;
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
    [HideInInspector]
    public bool branchCut = false;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<BoxCollider>().isTrigger = false;
            if (this.GetComponent<Rigidbody>().useGravity == false)
            {

                this.GetComponent<Rigidbody>().useGravity = true;
                if (branchCut == false)
                {
                    branchCut = true;
                }
            }
        }
    }
}
