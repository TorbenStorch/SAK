using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanEnable : MonoBehaviour
{
    public GameObject canOpen;
    public GameObject canClose;
    private string sakTag = "CanOpener";

    void Start()
    {
        canClose.SetActive(true);
        canOpen.SetActive(false); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(sakTag))
        {
            canOpen.SetActive(true);
            canClose.SetActive(false);
        }
    }
}
