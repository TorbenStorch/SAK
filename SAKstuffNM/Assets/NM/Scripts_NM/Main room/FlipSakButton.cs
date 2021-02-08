using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: the script is starting flipping animation after button on pedestal was pressed. 
/// </summary>

public class FlipSakButton : MonoBehaviour
{
    public GameObject SAK; // Big Swiss Army Knife (has to be assigned)
    private Animator SAKAnimator; // Animator of Big Swiss Army Knife

    // Observer
    public UnityEvent flippingAnimationButtonPressed;

    void Start()
    {
        // Assign animator from Swiss Army Knife
        SAKAnimator = SAK.GetComponent<Animator>();
    }
    // Flipping for Testing
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SAKAnimator.SetBool("Open", true);
        }
    }
    // Flipping in VR
    public void OnCustomButtonPress()
    {
        // Usual
        SAKAnimator.SetBool("Open", true);
    }
}