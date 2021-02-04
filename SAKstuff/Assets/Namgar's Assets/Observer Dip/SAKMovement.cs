using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for big swiss army knife animations and animator.
/// 2) Has to be connected with "EventObserver" interface for flipping animation.
/// 3) Part of the observer pattern.
/// </summary>

public class SAKMovement : MonoBehaviour
{
    private Animator SAKanim;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        SAKanim = GetComponent<Animator>();
    }

    public void Flip()
    {
        // Flipping animation starts, if SAK is closed
        if(open == false)
        {
            Debug.Log("Flipped");
            SAKanim.SetBool("Open", true);
            open = true;
        }
        else // Unflipping animation starts, if SAK is opened
        {
            Debug.Log("Unflipped");
            SAKanim.SetBool("Open", false);
            open = false;
        }
    }
}
