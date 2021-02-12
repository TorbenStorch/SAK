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
    public GameObject toolMenuPoint;

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

            // Trying to make own rotation  works, problem only with length
            //float xVal = leftHand.transform.position.x*10 * Mathf.Cos(1.5708f) - leftHand.transform.position.z*10 * Mathf.Sin(1.5708f);
            //pointer.transform.localPosition = new Vector3(xVal, 0, 0);

            // Next - compute angle from rotated canvas/tool menu and z(0,0,1) and put it in xVal7
            // Changed in inspector from tool menu point to canvas object

            /*float dotProduct = zPos.x * toolMenu.transform.position.x +
                               zPos.y * toolMenu.transform.position.y +
                               zPos.z * toolMenu.transform.position.z;
            float dotDiv = dotProduct/()*/
            // Nope, I will use ERMath
            vDirection = toolMenu.transform.position - new Vector3(0, 0, 1);
            Coords dirNorm = ERMath.GetNormal(new Coords(vDirection));
            vDirection = dirNorm.ToVector();
            float angle = ERMath.Angle(new Coords(0, 0, 1), new Coords(vDirection));
            Debug.Log(angle * 180.0f / Mathf.PI);
            float xVal = leftHand.transform.position.x * Mathf.Cos(angle) - leftHand.transform.position.z * Mathf.Sin(angle);
            //float zVal = leftHand.transform.position.x * Mathf.Sin(angle) + leftHand.transform.position.z * Mathf.Cos(angle);
            // Need adjustable changer of angle ???
            if(angle > 3.14 && angle < 6.28)
            {
                pointer.transform.localPosition = new Vector3(-xVal * 100, leftHand.transform.position.y * 100, 0);
            } else
            {
                pointer.transform.localPosition = new Vector3(xVal * 100, leftHand.transform.position.y * 100, 0);
            }
            


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
