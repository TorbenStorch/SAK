using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestelDoor : MonoBehaviour
{
    public float pedestelSpeed = 1f;
    // End position for the Hatch's door while get closed
    public float pedClosePos = 0.0015f;
    //public float pedOpenPos = -0.0122f;
    public float timeUntilClose = 2f;
    public bool activatePed;
    private bool goUp = false;

    void pedClose ()
    {
        goUp = true;
        if (transform.position.y < pedClosePos)
        {
            transform.position += new Vector3(0, pedestelSpeed * Time.deltaTime, 0);
        }
    }


    //void Start()
    //{
    //    this.transform.position = new Vector3(transform.position.x, pedClosePos, transform.position.z);
    //}
    void Update()
    {
        if (activatePed && !goUp)
        {
            transform.position -= new Vector3(0, pedestelSpeed * Time.deltaTime, 0);
            Invoke("pedClose", timeUntilClose);
        }
    }
}
