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
