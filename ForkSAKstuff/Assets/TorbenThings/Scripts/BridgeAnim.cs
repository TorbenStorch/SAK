/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for activating the bridge fall animation i made (called BridgeAnimation), once the rope got cut
/// 2) Has to be connceted with the Animator (BridgeFallAnimation - controller)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnim : MonoBehaviour
{
    public CutRope cutRopeScript;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (cutRopeScript.ropeCut)
        {
            anim.SetTrigger("fallBridge");
        }
    }
}
