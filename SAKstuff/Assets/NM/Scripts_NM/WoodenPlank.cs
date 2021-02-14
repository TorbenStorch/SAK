using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : MonoBehaviour
{
    public GameObject[] screws;
    public int amount;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        amount = screws.Length;
    }

    private void Update()
    {
        if(amount == 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
