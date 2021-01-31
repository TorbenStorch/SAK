using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for switching on and off Tool Menu
/// 2) Has to be connected with "EventObserver" interface-script in inspector and with corrsponding Switch Tool Menu event for switching.
/// 3) Part of the observer pattern.
/// </summary>

public class ToolMenu : MonoBehaviour
{
    public Image iToolMenu;
    private bool open = false;

    void Start()
    {
        iToolMenu.enabled = false; // enable Tool Menu image
    }

    public void Switch()
    {
        if(open == false)
        {
            iToolMenu.enabled = true;
            open = true;
        } else
        {
            iToolMenu.enabled = false;
            open = false;
        }
    }
}
