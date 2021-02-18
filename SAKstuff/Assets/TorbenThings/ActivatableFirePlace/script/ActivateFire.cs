/////////////////////////////////
//Script to Acitvate a Fire Place
/////////////////////////////////
/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for activating the campfire after branches got put into the campfire-trigger-box -> activate fire-particles & logs
/// 2) Has to be connceted with a particle system & logs-objects & branch-objects


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFire : MonoBehaviour
{
    private int branchCounter = 0;
    public int branchesNeeded = 3;
    private int logCounter = 0;

    public GameObject[] fireParticles;
    public GameObject[] branches;
    public GameObject[] logs;

    public bool fireIsOn = false;

    private void Start()
    {
        foreach (GameObject log in logs)
        {
            log.SetActive(false);
        }
        foreach (var particleSystem in fireParticles)
        {
            particleSystem.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject branch in branches)
        {
            if (other == branch.GetComponent<Collider>())
            {
                //activate log objects
                if(logCounter < logs.Length)//if there are more branches then logs
                {
                    logs[logCounter].SetActive(true);
                    logCounter += 1;
                }

                //look at branches input
                branchCounter += 1;
                if (branchCounter >= branchesNeeded)
                {
                    foreach (var particleSystem in fireParticles)
                    {
                        particleSystem.SetActive(true);
                    }
                    fireIsOn = true;
                }

                branch.SetActive(false); //deactivate the branch after dropping it into fireplace
            }
        }
    }
}
