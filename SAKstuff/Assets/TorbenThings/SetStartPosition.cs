using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;
    }

}
