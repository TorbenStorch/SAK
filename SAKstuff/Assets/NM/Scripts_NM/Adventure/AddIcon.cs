using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool adventureStarted = false; // if it is true - it was for testing
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
    // For audio
    private GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        icons = GameObject.FindGameObjectsWithTag("Icon");
    }

    // Update is called once per frame
    void Update()
    {
        // Check, if it is Adventure scene
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Adventure")
        {
            adventureStarted = true;
            // Add audio manager
            audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        }

        if (adventureStarted == true)
        {
            // Find all objects
            FindObj();

            // Disable icons, except knife, if the adventure started
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
                EnableIcon("CanOpenerIcon");
            }
            // Enable can opener
            if (can.GetComponent<CanEnable>().canOpened == true)
            {
                EnableIcon("BottleOpenerIcon");
            }
            // Enable bottle opener
            if (bottle.GetComponent<BottleOpener>().bottleOpened == true)
            {
                EnableIcon("SawIcon");
            }
            // Enable home icon
            if (branch.GetComponent<CutBranch>().branchCut == true)
            {
                EnableIcon("HomeIcon");
                EnableIcon("AdventureIcon");
            }
        }
    }

    private void FindObj()
    {
        // Find rope
        if (rope == null)
        {
            rope = GameObject.FindGameObjectWithTag("Rope");
        }
        // Find flashlight
        if (flashlight == null)
        {
            flashlight = GameObject.FindGameObjectWithTag("SmallSAK");
        }
        // Screw
        if (screw == null)
        {
            screw = GameObject.FindGameObjectWithTag("Screw");
        }
        // Branch
        if (branch == null)
        {
            branch = GameObject.FindGameObjectWithTag("Branch");
        }
        // Can
        if (can == null)
        {
            can = GameObject.FindGameObjectWithTag("Can");
        }
        // Bottle
        if (bottle == null)
        {
            bottle = GameObject.FindGameObjectWithTag("Bottle");
        }
    }

    private void DisableIcons()
    {
        for (int counter = 0; counter < icons.Length; counter++)
        {
            // Activate image for home icon and adventure icon
            //if(icons[counter].name == "HomeIcon" || icons[counter].name == "AdventureIcon")
            //{
                //icons[counter].GetComponent<Image>().enabled = true;
            //}

            // Disable all icons
            icons[counter].SetActive(false);

            // Except knife
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
