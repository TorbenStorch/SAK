using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// p.s. This was moved to script SAK move

public class SAKled : MonoBehaviour
{
    bool ledState;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ledState = !ledState;

            if(ledState)
                this.GetComponent<Light>().intensity = 2f;
            else
                this.GetComponent<Light>().intensity = 0f;
        }
    }
}
