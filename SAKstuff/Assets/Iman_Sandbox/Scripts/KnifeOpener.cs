using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class KnifeOpener : MonoBehaviour
{
    public Animator animator;
   
    public void OncustomedButton ()
    {
        Debug.Log("test");
    }
    public void OnPress(Handheld hand)
    {
        bool open = animator.GetBool("open");
        open = !open;
        animator.SetBool("open", open);
        Debug.Log("Button pressed");
    }

}
