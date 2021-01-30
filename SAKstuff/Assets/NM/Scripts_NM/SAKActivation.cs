using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SAKActivation : MonoBehaviour
{
    private bool start = false;

    public void Activate()
    {
        Debug.Log("It starts");
        start = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true || Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("We are ready");
        }
    }
}
