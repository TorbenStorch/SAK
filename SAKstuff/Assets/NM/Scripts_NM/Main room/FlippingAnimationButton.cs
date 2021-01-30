using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// </summary>

public class FlippingAnimationButton : MonoBehaviour
{
    private bool open = false;
    // Observer
    public UnityEvent flippingAnimationButtonPressed;

    // For testing without vr controllers
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Flipping starts");
            flippingAnimationButtonPressed.Occured();
        }
    }

    // Is this to access to steam vr?
    public void OnPress(Handheld hand)
    {
        Debug.Log("SteamVR Button was pressed");
    }

    // Flipping in VR
    public void OnCustomButtonPress()
    {
        if (open == false)
        {
            // Observer
            flippingAnimationButtonPressed.Occured();
        } else
        {
            //flippingAnimationButtonPressed.Reoccured???(); reocurred and then access to another animation
            // or unregister??? but then it will just delete observer from list, and it is wrong for us because we need to re-use
        }
    }
}
