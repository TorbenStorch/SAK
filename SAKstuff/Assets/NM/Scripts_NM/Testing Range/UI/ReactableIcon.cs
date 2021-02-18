using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for:
///     1. Giving a signal to small swiss army knife's animations;
///     2. Interacting with icons
///     3. Reaction of icons on interaction (divide it)
/// 2) Connected with "SmallSAKMove" script, game object small SAK and with icons
/// 3) Has to be connected with corrsponding "IconSelected" Menu event for switching.
/// 4) Part of the observer pattern.
/// </summary>

public class ReactableIcon : MonoBehaviour
{
    public bool switchOn = false;
    public Sprite selectedIcon; // Sprite with selected version of icon
    public Sprite unselectedIcon; // Sprite with unselected version of icon
    private Image currentIcon; // Current image
    private bool touched = false; // boolean to show that the pointer is hovering or not
    private GameObject[] icons;// array for icons

    // For selected and not selected mode
    public UnityEvent unselected;
    public UnityEvent selected;

    // For changing size of icon
    private Vector2 initialSize;

    // For audio
    private GameObject audioManager;

    private void Awake()
    {
        // Assign initial size
        initialSize = this.gameObject.GetComponent<Image>().rectTransform.sizeDelta;

        // For sound
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");

        // For storing icons in one array
        if (icons == null)
        {
            icons = GameObject.FindGameObjectsWithTag("Icon");
        }

    }

    // This method gives signal to the icon to start reacting, when the pointer is hovering above the icon
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            touched = true;
            Reaction();
        }
    }

    // This method give signal to icon to stop reacting, when the pointer stops hovering above the icon
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            touched = false;
            Reaction();
        }
    }

    // This method contains different sizes for reacting and non-reacting icon
    private void Reaction()
    {
        if (touched == true)
        {
            //audioManager.GetComponent<AudioManager>().Play("UI Items");
            this.gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(90, 90);
        } else
        {
            this.gameObject.GetComponent<Image>().rectTransform.sizeDelta = initialSize;
        }
    }
    // When trigger was pressed once and pointer is hovering above the icon, the icon is selected.
    public void Selection()
    {
        if(touched == true)
        {
            //selected.Occured();
            //readyForSmallSAKAnimation.Transferred(this.gameObject); // for SAK
            if (switchOn == false)
            {
                foreach(GameObject icon in icons)
                {
                    icon.GetComponent<ReactableIcon>().Unselect();
                    icon.GetComponent<ReactableIcon>().switchOn = false;
                }
                switchOn = true;
                Select();
            } else
            {
                switchOn = false;
                Unselect();
            }
        }
    }

    private void Select()
    {
        audioManager.GetComponent<AudioManager>().Play("UI Clicking");
        currentIcon = this.GetComponent<Image>();
        currentIcon.sprite = selectedIcon;
        selected.Occured();
    }

    private void Unselect()
    {
        currentIcon = this.GetComponent<Image>();
        currentIcon.sprite = unselectedIcon;
        unselected.Occured();
    }
}
