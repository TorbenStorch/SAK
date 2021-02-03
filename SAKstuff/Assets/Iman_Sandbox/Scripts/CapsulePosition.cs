using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePosition : MonoBehaviour
{
    [HideInInspector]
    public bool activate;

    [Range(0.2f, 2f)]
    [Tooltip("Ascending speed of the knife")]
    public float speed = 1f;
    public float endPosition = -1.106f;


    private void Start()
    {
        //to make the freeze-rotation work (otherwise it wont be consistent)
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
    }
    void Update()
    {
        if (activate)
        {
            if (transform.position.y <= endPosition)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            if (transform.position.y >= endPosition)
            {
                var colls = this.GetComponentsInChildren<MeshCollider>();
                foreach (var collider in colls)
                {
                    collider.enabled = true;
                    //dont collide with itselfe
                    Physics.IgnoreCollision(collider, this.GetComponent<Collider>()); 
                    Physics.IgnoreCollision(collider, collider);
                }
            }
        }
    }

}
