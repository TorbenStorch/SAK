using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeOpener : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // ask animator state then change it to another state and then set it and store it again.
        if(Input.GetKeyDown(KeyCode.O))
        {
            bool open = animator.GetBool("open");
            open = !open;
            animator.SetBool("open", open);
        }
    }
}
