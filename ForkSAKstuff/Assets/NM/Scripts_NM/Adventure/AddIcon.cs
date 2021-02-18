using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for switching/adding icon after the aim was fulfilled
/// 2) Has to be connected with Tool Menu object
/// 3) Objects with scripts have to be assigned in inspector
/// </summary>
/// 
public class AddIcon : MonoBehaviour
{
    private bool iconsDisabled = false;
    private bool adventureStarted = true; // if it is true - it was for testing
    // Objects that showes changes
    public GameObject rope;
    public GameObject flashlight; // SAK object with script small sak move
    public GameObject screw;
    public GameObject branch;
    public GameObject can;
    public GameObject bottle;
    private bool flashlightReady = false;
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
        if (adventureStarted == true)
        {
            if (iconsDisabled == false)
            {
                DisableIcons();
            }

            // Enable flashligh
            if (rope.GetComponent<CutRope>().ropeCut == true)
            {
                if(flashlight== null)
                {
                    flashlight = GameObject.FindGameObjectWithTag("SmallSAK");
                }
                EnableIcon("FlashlightIcon");
                flashlightReady = true;
            }
            // Enable screw driver
            if (flashlightReady == true)
            {
                if(flashlight.GetComponent<SmallSAKMove>().flashlightUsed == true)
                {
                    EnableIcon("ScrewDriverIcon");
                }
            }
            // Enable saw
            if (screw.GetComponent<ScrewOpener>().screwOpened == true)
            {
                EnableIcon("SawIcon");
            }
            // Enable can opener
            if (branch.GetComponent<CutBranch>().branchCut == true)
            {
                EnableIcon("CanOpenerIcon");
            }
            // Enable bottle opener
            if (can.GetComponent<CanEnable>().canOpened == true)
            {
                EnableIcon("BottleOpenerIcon");
            }
            // Enable home icon
            if (bottle.GetComponent<BottleOpener>().bottleOpened == true)
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
            if (icons[counter].name == "KnifeIcon")
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
