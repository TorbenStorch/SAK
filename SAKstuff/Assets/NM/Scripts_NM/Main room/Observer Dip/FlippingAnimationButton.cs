using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for interaction with logo button for flipping animation.
/// 2) Has to be connected with event "flipping animation button Pressed".
/// 3) Part of the observer pattern.
/// </summary>

public class FlippingAnimationButton : MonoBehaviour
{
    // Observer
    public UnityEvent flippingAnimationButtonPressed;

    // For testing without vr controllers
    private void Update()
    {
        //TestVR();
    }

    /*public void TestVR()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Flipping starts");
            flippingAnimationButtonPressed.Occured();
        }
    }*/

    // Is this to access to steam vr?
    /*public void OnPress(Handheld hand)
    {
        Debug.Log("SteamVR Button was pressed");
    }*/

    // Flipping in VR
    // Add this to object(Button or pedestal) with script "Hover Button": in inspector "On Button Down(Hand)"
    public void OnFlippingAnimationButtonPress()
    {
        Debug.Log("Flipping starts");
        flippingAnimationButtonPressed.Occured();
    }
}
