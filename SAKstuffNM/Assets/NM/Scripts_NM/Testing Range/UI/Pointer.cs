using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for Pointer moving
/// 2) Has to be connceted with appropriate Pointer object, also, other objects have to be assigned in inspector in script
/// 3) Part of the observer pattern.
/// </summary>
/// 
public class Pointer : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject pointer;
    public GameObject toolMenu;
    private Vector3 pointerPos; 
    private float offset; // offset as a sing of inage's border
    private bool switchOn = false; // shows, if menu button on right controller was pressed

    private void Start()
    {
        offset = 0.25f; 
    }

    private void Update()
    {
        // If menu button on right controller was pressed once, the pointer starts to move
        if(switchOn == true)
        {
            //this.transform.rotation = leftHand.transform.rotation;

            pointerPos.x = leftHand.transform.position.x;
            pointerPos.y = leftHand.transform.position.y;
            pointerPos.z = toolMenu.transform.position.z;

            if (leftHand.transform.position.x > toolMenu.transform.position.x - offset &&//toolMenuPos.anchorMin.x &&
                leftHand.transform.position.y > toolMenu.transform.position.y - offset &&
                leftHand.transform.position.z > toolMenu.transform.position.z - offset &&
                leftHand.transform.position.x < toolMenu.transform.position.x + offset &&
                leftHand.transform.position.y < toolMenu.transform.position.y + offset &&
                leftHand.transform.position.z < toolMenu.transform.position.z + offset)
            {
                pointer.transform.position = pointerPos;
            }
        }
    }
    // If menu button was pressed, boolean for movement is switched
    public void PointerMove()
    {
        if(switchOn == false)
        {
            switchOn = true;
        } else
        {
            switchOn = false;
        }
    }
}
