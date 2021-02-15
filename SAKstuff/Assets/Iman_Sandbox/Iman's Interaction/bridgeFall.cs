using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeFall : MonoBehaviour
{
    public GameObject bridge;
    public bool cut = false;
    public Animator anim;

    void Start()
    {
            
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            cut = true;
            anim.SetBool("fall", true);
        }
    }
}
