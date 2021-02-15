using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for adding icon-tool in tool menu
/// 2) Has to be connceted with Tool menu (in Canvas)
/// </summary>
public class AddIcon : MonoBehaviour
{
    private bool iconsDisabled = false;
    private bool adventureStarted = false;
    // Objects that showes changes
    private GameObject rope;
    private GameObject flashlight; // SAK object with script small sak move
    private GameObject screw;
    private GameObject branch;
    private GameObject can;
    private GameObject bottle;
    // For an array from all icons
    private GameObject[] icons;
    // Start is called before the first frame update
    void Start()
    {
        icons = GameObject.FindGameObjectsWithTag("Icon");
    }

    // Update is called once per frame
    void Update()
    {
        // Disable icons, except knife, if the adventure started
        if(adventureStarted == true)
        {
            if (iconsDisabled == false)
            {
                DisableIcons();
            }
            
            // Enable flashligh
            if(rope.GetComponent<CutRope>().ropeCut == true)
            {
                EnableIcon("FlashlightIcon");
            }
            // Enable screw driver
            else if (flashlight.GetComponent<SmallSAKMove>().flashlightUsed == true)
            {
                EnableIcon("ScrewDriverIcon");
            }
            // Enable saw
            else if(screw.GetComponent<ScrewOpener>().screwOpened == true)
            {
                EnableIcon("SawIcon");
            }
            // Enable can opener
            else if(branch.GetComponent<CutBranch>().branchCut == true)
            {
                EnableIcon("CanOpenerIcon");
            }
            // Enable bottle opener
            else if (can.GetComponent<CanEnable>().canOpened == true)
            {
                EnableIcon("BottleOpenerIcon");
            }
            // Enable home icon
            else if (bottle.GetComponent<BottleOpener>().bottleOpened == true)
            {
                EnableIcon("HomeIcon");
                EnableIcon("AdventureIcon");
            }
        }
    }

    private void DisableIcons()
    {
        for (int counter = 0; counter < icons.Length; counter++)
        {
            icons[counter].SetActive(false);
            if(icons[counter].name == "KnifeIcon")
            {
                icons[counter].SetActive(true);
            }
        }
        iconsDisabled = true;


    }

    private void EnableIcon(string name)
    {
        for (int counter = 0; counter < icons.Length; counter++)
        {
            if (icons[counter].name == name)
            {
                icons[counter].SetActive(true);
            }
        }
    }


}
