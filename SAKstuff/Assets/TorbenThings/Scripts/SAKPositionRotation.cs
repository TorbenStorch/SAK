/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for moving the SAK up (also hereby deactivation of collision with itselve), allowing rotation and allowing you to use the button-interaction (removeing a cover-collider)
/// 2) Has to be connceted with the giant SAK and its Rigidbody (to allow better freezing of the positions), also the animation-start-bool will be used from TriggerLine1 script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SAKPositionRotation : MonoBehaviour
{
    public bool activate;

    public float speed = 1f;
    public float endPosition = -1.106f;

    public GameObject SAKButton;
    public Collider SAKButtonColliderCover;

    private void Start()
    {
        //to make the freeze-rotation work (otherwise it wont be consistent)
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        GetComponent<CapsuleCollider>().enabled = false;

        SAKButton.GetComponent<MeshCollider>().enabled = false; //make the button to flip tools inactive -> you should not click it before SAK is fully there
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
                GetComponent<CapsuleCollider>().enabled = true;
                SAKButtonColliderCover.enabled = false;
                SAKButton.GetComponent<MeshCollider>().enabled = true;
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
