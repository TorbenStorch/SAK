using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// P3 Swiss Army Knife project
/// Namgar Mardvaeva
/// Group № 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for cutting movement of the rope
/// 2) There have to be two parts of rope:
/// 3) This script has to be connceted with down part of rope
/// 4) On the down rope has to be rigidbody (uncheck - use gravity andvis kinematic) and collider (above cutting place)
/// </summary>
public class CutRope : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SAK")
        {
            // When gravity is switched on - down part will fall
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
