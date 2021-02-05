using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class MoveCubeTest : MonoBehaviour
{
    public SteamVR_Action_Boolean selectionMode;
    public GameObject leftHand;
    public GameObject pointer;
    public GameObject toolMenu;
    private Vector3 pointerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        //toolMenuPos = toolMenuImage.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (selectionMode.state == true) // works with clicking
        {
            pointerPos.x = leftHand.transform.position.x;
            pointerPos.y = leftHand.transform.position.y;
            pointerPos.z = toolMenu.transform.position.z;

            if (leftHand.transform.position.x > toolMenu.transform.position.x - 0.25f &&//toolMenuPos.anchorMin.x &&
                leftHand.transform.position.y > toolMenu.transform.position.y - 0.25f &&
                leftHand.transform.position.x < toolMenu.transform.position.x + 0.25f &&
                leftHand.transform.position.y < toolMenu.transform.position.y + 0.25f)
            {
                pointer.transform.position = pointerPos;
            }
        } else
        {
            Debug.Log("Not Ready");
        }
    }
}
