using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePosition : MonoBehaviour
{
    [HideInInspector]
    public bool activate;

    [Range(0.2f, 15f)]
    [Tooltip("Ascending speed of the knife")]
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float endPosition = -1.106f;

    //private new Rigidbody rigidbody;

    //void Awake()
    //{
    //    rigidbody = GetComponent<Rigidbody>();
    //}

    
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    rigidbody.AddTorque(0, rotationSpeed, 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    rigidbody.AddTorque(0, -rotationSpeed, 0);
        //}

        if (activate)
        {
            if (transform.position.y <= endPosition)
            {
                //rigidbody.isKinematic = true;
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else
            {
                //rigidbody.isKinematic = false;
            }
        }
    }
}
