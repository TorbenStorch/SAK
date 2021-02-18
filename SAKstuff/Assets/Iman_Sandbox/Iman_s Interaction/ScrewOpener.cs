/// P3 Swiss Army Knife project
/// All
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewOpener : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public float moveSpeed = 1f;
    public bool touched;
    public Vector3 endPos = new Vector3(0.232f, 5f, 0f);

    public GameObject woodenPlank;

    private string sakTag = "ScrewDriver";
    // For adventure
    [HideInInspector]
    public bool screwOpened = false;
    private GameObject audioManager;


    //[Header("Srew Direction")]
    //public bool directionX;
    //public bool directionY;
    //public bool directionZ;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(sakTag))
        {
            // For audio
            audioManager.GetComponent<AudioManager>().Play("Screw");

            // For adventure
            if (screwOpened == false)
            {
                screwOpened = true;
            }

            // For screw's movement
            touched = true;

            //FindObjectOfType<WoodenPlank>().amount -= 1; // -> if we have more woodenPlanks in the scene that wont work
            woodenPlank.GetComponent<WoodenPlank>().amount -= 1;
        }
    }

    private void Update()
    {
        //if (transform.position.x >= endPos.x)
        //{
        //    dropDown();
        //}

        ////quick fix - no time to make it better :D
        //if (directionX)
        //{
        //    if (transform.localPosition.x >= endPos.x)
        //    {
        //        dropDown();
        //    }
        //}
        ////quick fix - no time to make it better :D
        //if (directionY)
        //{
        //    if (transform.localPosition.y >= endPos.y)
        //    {
        //        dropDown();
        //    }
        //}
        //quick fix - no time to make it better :D
        //if (directionZ)
        //{
        //    if (transform.localPosition.z >= endPos.z)
        //    {
        //        dropDown();
        //    }
        //}

        if (transform.localPosition.z >= endPos.z)
        {
            dropDown();
        }

        if (touched)
        {
            transform.eulerAngles += new Vector3(0f, 0f, -(rotationSpeed * Time.deltaTime));

            transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime;

            ////quick fix - no time to make it better :D
            //if (directionX)
            //{
            //    transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
            //}
            //if (directionY)
            //{
            //    transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
            //}
            //if (directionZ)
            //{
            //    transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime;
            //}
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
    void dropDown()
    {
        //audioManager.GetComponent<AudioManager>().Play("Screw");
        touched = false;
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
