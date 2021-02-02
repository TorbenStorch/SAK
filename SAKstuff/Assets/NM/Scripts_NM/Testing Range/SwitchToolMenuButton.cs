using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using UnityEngine.UI;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for giving signal that Tool Menu has to be switched off
/// 2) Has to be connceted with appropriate Button (control stick on VR controllers)
/// 3) Part of the observer pattern.
/// 4) Without VR glasses could be used with C.
/// </summary>

public class SwitchToolMenuButton : MonoBehaviour
{
    public UnityEvent SwitchToolMenu;
    public SteamVR_Action_Boolean switchToolMenu;

    // For testing with VR glasses
    void Update()
    {
        if(switchToolMenu.state == true)
        {
            SwitchToolMenu.Occured();
        }

        // For testing with VR glasses
        //TestVR();
    }

    /*public void TestVR()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchToolMenu.Occured();
        }
    }*/

    public void OnPress (Handheld hand)
    {
        
    }
    // Switching tool menu in VR
    // Add this to object(Button) with script "Hover Button": in inspector "On Button Down(Hand)"
    public void OnSwitchToolMenuButtonPress()
    {
        SwitchToolMenu.Occured();
    }

}
