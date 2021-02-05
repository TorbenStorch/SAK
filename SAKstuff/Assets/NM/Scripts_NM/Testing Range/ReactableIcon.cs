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
    private bool switchOn = false;
    public UnityEvent touchedIcon;
    public Sprite selectedIcon; // Sprite with selected version of icon
    public Sprite unselectedIcon; // Sprite with unselected version of icon
    private Image currentIcon; // Current image
    private bool bigger = false; // boolean to show that the pointer is hovering or not

    private void Start()
    {
        Debug.Log("this.gameObject.name:" + this.gameObject.name);
    }

    // This method gives signal to the icon to start reacting, when the pointer is hovering above the icon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pointer")
        {
            bigger = true;
            Reaction();
            // Signal for observers
            touchedIcon.Transferred(this.gameObject.name);
        }
    }
    // This method give signal to icon to stop reacting, when the pointer stops hovering above the icon.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Pointer")
        {
            bigger = false;
            Reaction();
        }
    }
    // This method contains different sizes for reacting and non-reacting icon
    private void Reaction()
    {
        if(bigger == true)
        {
            this.gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(100, 100);
            bigger = false;
        } else
        {
            this.gameObject.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(80, 80);
        }
    }
    // When trigger was pressed once and pointer is hovering above the icon, the icon is selected.
    public void Selection()
    {
        if (switchOn == false)
        {
            bigger = false;
            Reaction();
            // Icon reaction on selection
            Debug.Log("2dPointer touched icon");
            currentIcon = this.GetComponent<Image>();
            currentIcon.sprite = selectedIcon;
            switchOn = true;
        }
        else
        {
            // When trigger was pressed second time, the icon is unselected  
            currentIcon = this.GetComponent<Image>();
            currentIcon.sprite = unselectedIcon;
            switchOn = false;
        }
    }
}
