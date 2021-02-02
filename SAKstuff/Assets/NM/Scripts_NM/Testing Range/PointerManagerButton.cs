using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PointerManagerButton : MonoBehaviour
{
    public UnityEvent pointerManagerButtonPressed;
    private bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // For testing in VR
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TestVR();
        }
    }

    public void TestVR()
    {
        Debug.Log("Selection mode starts");
        pointerManagerButtonPressed.Occured();
    }


}
