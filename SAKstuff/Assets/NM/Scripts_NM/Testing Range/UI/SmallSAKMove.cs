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
    // Animation clips Hashes
    // Open animation
    private int[] OpenAnimations;
    private int OpenKnife = Animator.StringToHash("OpenKnife");
    private int SwitchOnFlashlight = Animator.StringToHash("SwitchOnFlashlight");
    private int OpenScrewDriver = Animator.StringToHash("OpenScrewDriver");
    private int OpenSaw = Animator.StringToHash("OpenSaw");
    private int OpenCanOpener = Animator.StringToHash("OpenCanOpener");
    private int OpenBottleOpener = Animator.StringToHash("OpenBottleOpener");

    // Close Animation:
    private int[] CloseAnimations;
    private int CloseKnife = Animator.StringToHash("CloseKnife");
    private int SwitchOffFlashlight = Animator.StringToHash("SwitchOffFlashlight");
    private int CloseScrewDriver = Animator.StringToHash("CloseScrewDriver");
    private int CloseSaw = Animator.StringToHash("CloseSaw");
    private int CloseCanOpener = Animator.StringToHash("CloseCanOpener");
    private int CloseBottleOpener = Animator.StringToHash("CloseBottleOpener");

    // Parameter Hashs:
    // Open animation
    private int [] OpenParameters;
    private int DoOpenKnife = Animator.StringToHash("DoOpenKnife");
    private int DoSwitchOnFlashlight = Animator.StringToHash("DoSwitchOnFlashlight");
    private int DoOpenScrewDriver = Animator.StringToHash("DoOpenScrewDriver");
    private int DoOpenSaw = Animator.StringToHash("DoOpenSaw");
    private int DoOpenCanOpener = Animator.StringToHash("DoOpenCanOpener");
    private int DoOpenBottleOpener = Animator.StringToHash("DoOpenBottleOpener");

    // Close Animation:
    private int[] CloseParameters;
    private int DoCloseKnife = Animator.StringToHash("DoCloseKnife");
    private int DoSwitchOffFlashlight = Animator.StringToHash("DoSwitchOffFlashlight");
    private int DoCloseScrewDriver = Animator.StringToHash("DoCloseScrewDriver");
    private int DoCloseSaw = Animator.StringToHash("DoCloseSaw");
    private int DoCloseCanOpener = Animator.StringToHash("DoCloseCanOpener");
    private int DoCloseBottleOpener = Animator.StringToHash("DoCloseBottleOpener");

    // Connection with tool
    private string toolName;
    private GameObject[] icons;

    // For adventure
    //[HideInInspector]
    public bool flashlightUsed = false;
    public bool adventureStarted = true;
    private GameObject audioManager;

    // For singleton
    public static SmallSAKMove Instance { set; get; }

    // Start is called before the first frame update
    void Awake()
    {
        // Singleton for adventure
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        // For animation
        anim = GetComponent<Animator>();
        icons = GameObject.FindGameObjectsWithTag("Icon");
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    // If trigger was pressed & pointer was above icon, animation starts
    public void StartAnimation()
    {
        // Reload icons
        if(adventureStarted == true)
        {
            icons = GameObject.FindGameObjectsWithTag("Icon");
        }
        // Check which icon was enabled
        foreach(GameObject icon in icons)
        {
            if(icon.GetComponent<ReactableIcon>().switchOn == true)
            {
                toolName = icon.name;
                Debug.Log(toolName);
            }
        }

        // Icons
        if (toolName == "KnifeIcon")
        {
            anim.ResetTrigger("DoCloseKnife");
            anim.SetTrigger("DoOpenKnife");
        }
        else if (toolName == "ScrewDriverIcon")
        {
            anim.ResetTrigger("DoCloseScrewDriver");
            anim.SetTrigger("DoOpenScrewDriver");
        } else if (toolName == "SawIcon")
        {
            anim.ResetTrigger("DoCloseSaw");
            anim.SetTrigger("DoOpenSaw");
            
        }
        else if (toolName == "BottleOpenerIcon")
        {
            anim.ResetTrigger("DoCloseBotOpen");
            anim.SetTrigger("DoOpenBotOpen");
        } 
        else if (toolName == "CanOpenerIcon")
        {
            anim.ResetTrigger("DoCloseCanOpen");
            anim.SetTrigger("DoOpenCanOpen");
        }
        else if (toolName == "FlashlightIcon")
        {
            Debug.Log("Light was switched on");
            // For switching light
            //audioManager.GetComponent<AudioManager>().Play("Flashlight");
            this.gameObject.GetComponentInChildren<Light>().intensity = 2f;
            // For adventure
            AdventureFlashlight();
            // For animation
            anim.ResetTrigger("OffFlashlight");
            anim.SetTrigger("OnFlashlight");
        }
    }

    public void StopAnimation()
    {
        foreach (GameObject icon in icons)
        {
            if (icon.GetComponent<ReactableIcon>().switchOn == true)
            {
                toolName = icon.name;
            }
        }

        if (toolName == "KnifeIcon")
        {
            anim.ResetTrigger("DoOpenKnife");
            anim.SetTrigger("DoCloseKnife");
        }
        else if (toolName == "ScrewDriverIcon")
        {
            anim.ResetTrigger("DoOpenScrewDriver");
            anim.SetTrigger("DoCloseScrewDriver");
        }
        else if (toolName == "SawIcon")
        {
            anim.ResetTrigger("DoOpenSaw");
            anim.SetTrigger("DoCloseSaw");
        }
        else if (toolName == "BottleOpenerIcon")
        {
            anim.SetTrigger("DoCloseBotOpen");
            anim.ResetTrigger("DoOpenBotOpen");
        }
        else if (toolName == "CanOpenerIcon")
        {
            anim.SetTrigger("DoCloseCanOpen");
            anim.ResetTrigger("DoOpenCanOpen");
        }
        else if (toolName == "FlashlightIcon")
        {
            this.gameObject.GetComponentInChildren<Light>().intensity = 0f;
            anim.SetTrigger("OffFlashlight");
            anim.ResetTrigger("OnFlashlight");
        }
    }


    private void AdventureFlashlight()
    {
        if (flashlightUsed == false)
        {
            flashlightUsed = true;
        }
    }
}
