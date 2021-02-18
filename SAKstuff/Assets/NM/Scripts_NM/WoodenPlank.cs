/// P3 Swiss Army Knife project
/// All
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for letting the WoddenPlank fall down
/// 2) Has to be connceted with all the screws which should hold the wooden-plank in place (all screws need to be put into the array in the inspector)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : MonoBehaviour
{
    public GameObject[] screws;
    [HideInInspector]
    public int amount;

    public GameObject activateTeleport;


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
            if(activateTeleport != null)
            {
                activateTeleport.SetActive(true);
            }
        }
    }
}
