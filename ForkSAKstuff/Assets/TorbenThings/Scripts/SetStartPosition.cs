/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for setting the player into the right position after scene-switch

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        player.transform.position = transform.position;
    }

}
