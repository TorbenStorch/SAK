using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for switching on and off of small swiss army knife's animations
/// 2) Connected with "ReactableIcon" script and with icons
/// 3) Has to be connected with "EventObserver" interface-script in inspector and with corrsponding "IconSelected" Menu event for switching.
/// 4) Part of the observer pattern.
/// </summary>

public class SmallSAKMove : MonoBehaviour
{
    private Animator anim;
    private bool switchOn = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // If trigger was pressed & pointer was above icon, animation starts
    public void StartAnimation(string toolName)
    {
        if(switchOn == false)
        {
            if(toolName == "KnifeIcon")
            {
                anim.ResetTrigger("DoCloseKnife");
                anim.SetTrigger("DoOpenKnife");
            } else if(toolName == "TorchIcon")
            {
                anim.ResetTrigger("DoCloseScrewDriver");
                anim.SetTrigger("DoOpenScrewDriver");
            }
            
            switchOn = true;
        } else
        {
            if (toolName == "KnifeIcon")
            {
                anim.ResetTrigger("DoOpenKnife");
                anim.SetTrigger("DoCloseKnife");
            }
            else if (toolName == "TorchIcon")
            {
                anim.ResetTrigger("DoOpenScrewDriver");
                anim.SetTrigger("DoCloseScrewDriver");
            }
            
            switchOn = false;

        }
    }
}
