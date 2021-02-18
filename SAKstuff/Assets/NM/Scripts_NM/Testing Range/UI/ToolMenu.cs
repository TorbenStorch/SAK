using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image iPointerIcon;
    public Image iKnifeIcon;
    public Image iFlashlightIcon;
    public Image iScrewDriverIcon;
    public Image iSawIcon;
    public Image iCanOpenerIcon;
    public Image iBottleOpenerIcon;
    private bool open = false;
    private GameObject audioManager;

    private GameObject[] icons;

    void Awake()
    {
        SwitchOff();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");

        icons = GameObject.FindGameObjectsWithTag("Icon");
    }

    private void SwitchOn()
    {
        /*for(int counter = 0; counter < icons.Length; counter++)
        {
            icons[counter].GetComponent<Image>().enabled = true;
            // Special icons for adventure
            if (icons[counter].name == "HomeIcon" || icons[counter].name == "AdventureIcon")
            {
                if (SceneManager.GetActiveScene().name == "Adventure")
                {
                    icons[counter].GetComponent<Image>().enabled = true;
                } else
                {
                    icons[counter].GetComponent<Image>().enabled = false;
                }
            }
        }*/
        iToolMenu.enabled = true;
        iPointerIcon.enabled = true;
        iKnifeIcon.enabled = true;
        iFlashlightIcon.enabled = true;
        iScrewDriverIcon.enabled = true;
        iSawIcon.enabled = true;
        iBottleOpenerIcon.enabled = true;
        iCanOpenerIcon.enabled = true;
        
    }
    private void SwitchOff()
    {
        /*icons = GameObject.FindGameObjectsWithTag("Icon"); // Ask if it okay
        for (int counter = 0; counter < icons.Length; counter++)
        {
            icons[counter].GetComponent<Image>().enabled = false;
            // Special icons for adventure
            if (icons[counter].name == "HomeIcon" || icons[counter].name == "AdventureIcon")
            {
                if (SceneManager.GetActiveScene().name == "Adventure")
                {
                    icons[counter].GetComponent<Image>().enabled = true;
                }
                else
                {
                    icons[counter].GetComponent<Image>().enabled = false;
                }
            }
        }
        iToolMenu.enabled = false;
        iPointerIcon.enabled = false;*/
        iToolMenu.enabled = false;
        iPointerIcon.enabled = false;
        iKnifeIcon.enabled = false;
        iFlashlightIcon.enabled = false;
        iScrewDriverIcon.enabled = false;
        iSawIcon.enabled = false;
        iBottleOpenerIcon.enabled = false;
        iCanOpenerIcon.enabled = false;
    }
    // If menu button was pressed, switch on/off the menu tool
    public void Switch()
    {
        audioManager.GetComponent<AudioManager>().Play("UI Menu");
        if(open == false)
        {
            SwitchOn();
            open = true;
        } else
        {
            SwitchOff();
            open = false;
        }
    }
}
