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
    public GameObject test;
    Vector3 testValue;
    private float offset; // offset as a sing of inage's border
    private bool switchOn = false; // shows, if menu button on right controller was pressed

    // var from math lecture
    Vector3 vDirection;
    bool clockwise = false;

    private void Start()
    {
        
        /*testValue.x = test.transform.localPosition.x *100;
        testValue.y = test.transform.localPosition.y * 100;
        //testValue.x = test.transform.localPosition.x * 10;
        pointer.transform.localPosition = testValue;*/
        offset = 0.25f; 
    }

    private void Update()
    {
        // If menu button on right controller was pressed once, the pointer starts to move
        if(switchOn == true)
        {
            // Trying to use information and scripts from lecture
            /*vDirection = toolMenu.transform.position - leftHand.transform.position;
            Coords dirNormal = ERMath.GetNormal(new Coords(vDirection));
            vDirection = dirNormal.ToVector();
            float angle = ERMath.Angle(new Coords(0, 0, 1), new Coords(vDirection));
            Coords newDir = ERMath.Rotate(new Coords(0, 0, 1), angle, true);
            Vector3 leftHandPos;
            leftHandPos = leftHand.transform.forward;
            leftHandPos = new Vector3(newDir.x, newDir.y, newDir.z);*/


            //pointer.transform.localPosition = new Vector3(leftHandPos.x*100, 0, 0);

            /*vDirection = toolMenu.transform.position - test.transform.position;
            Coords dirNormal = ERMath.GetNormal(new Coords(vDirection));
            vDirection = dirNormal.ToVector();
            float angle = ERMath.Angle(new Coords(0, 0, 1), new Coords(vDirection)); // I needed this angle to compute x,z of tool menu position
            
            Coords newDir = ERMath.Rotate(new Coords(0, 0, 1), angle, true);*/

            // Trying to make own rotation
            float xVal = leftHand.transform.position.x * Mathf.Cos(1.5708f) - leftHand.transform.position.z * Mathf.Sin(1.5708f);
            pointer.transform.localPosition = new Vector3(xVal*10, 0, 0);



            // new - doesn't rotate vector from comtroller - works only if controller looks forward in z direction
            //pointer.transform.localPosition = new Vector3(leftHand.transform.position.x*100,
            //  0,
            //0);

            // old, works with mistake
            //this.transform.rotation = leftHand.transform.rotation;

            /*pointerPos.x = leftHand.transform.position.x;
            pointerPos.y = leftHand.transform.position.y;
            pointerPos.z = toolMenu.transform.position.z;*/

            //pointer.transform.localPosition = pointerPos;

            /*if (leftHand.transform.position.x > toolMenu.transform.position.x - offset &&//toolMenuPos.anchorMin.x &&
                leftHand.transform.position.y > toolMenu.transform.position.y - offset &&
                //leftHand.transform.position.z > toolMenu.transform.position.z - offset &&
                leftHand.transform.position.x < toolMenu.transform.position.x + offset &&
                leftHand.transform.position.y < toolMenu.transform.position.y + offset //&&
                //leftHand.transform.position.z < toolMenu.transform.position.z + offset
                )
            {

                pointer.transform.localPosition = pointerPos;
            }*/
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
