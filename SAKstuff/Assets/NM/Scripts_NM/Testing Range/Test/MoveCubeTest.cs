using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class MoveCubeTest : MonoBehaviour
{
    public SteamVR_Action_Boolean selectionMode;
    public GameObject rightHand;
    public GameObject cube;
    public Image toolMenu;
    private Vector3 pointerPos;
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(selectionMode.state == true) // works with clicking
        {
            Debug.Log("Ready");
            pointerPos.x = rightHand.transform.position.x;
            pointerPos.y = rightHand.transform.position.y;
            pointerPos.z = toolMenu.transform.position.z;
            cube.transform.position = pointerPos;
        } else
        {
            Debug.Log("Not Ready");
        }
    }
}
