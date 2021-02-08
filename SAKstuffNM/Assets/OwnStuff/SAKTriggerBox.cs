﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAKTriggerBox : MonoBehaviour
{
    public bool touchedTrigger = false;
    public float timeToStartSpotlightsInSec = 10f;

    public Collider playerHand;

    [Header("Spotlights")]
    public GameObject allSpotlights; //we need ONE parent GameObject with all spotlights inside
    Light[] spotLights;

    private float lightIntesityValue; //value of the intenity
    private bool lightGoesOn = true; //this is true if the lights are not dimming down

    //here we can adjust everything in the implementation phase
    public float maxLightIntesity = 1.3f; //could be lower - should not be higher then 1.3f
    public float minLightIntesity = 0.5f; //maybe set that to 0f if we don't want light from the beginning?
    public float timeBeforeDimmingDownInSec = 5f;
    public float stepsItWillTakeUntilLightIsOnOrOff = 0.005f; //the lower the longer - if we want seperat times for start/end, we need two floats instead of one OR divide/multiply the value

    [Header("Door Animation")]
    public float stepsToMove = 0.1f;
    public float startYposition = 0.75f; //in this test the doors are closed at 0.75f - maybe different
    public float endYpositon = 2.1f; //in this test the doors are open at 2.1f - maybe different
    GameObject[] doors;


    private void OnTriggerEnter(Collider other)
    {
        if (other == playerHand)
        {
            touchedTrigger = true;
        }
    }

    void Awake()
    {
        if (allSpotlights == null) Debug.LogError("No Parent for spotlights connected");
        spotLights = allSpotlights.GetComponentsInChildren<Light>();

        doors = GameObject.FindGameObjectsWithTag("MoveDoor");
        if (doors == null) Debug.LogError("No doors found");
    }
    private void Start()
    {
        lightIntesityValue = minLightIntesity;
        foreach (Light light in spotLights)
        {
            light.intensity = lightIntesityValue;
        }
        foreach (GameObject door in doors) //set the door to the normal start position (normally not needed)
        {
            door.transform.position = new Vector3 (door.transform.position.x, startYposition, door.transform.position.z);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //just to test
        {
            touchedTrigger = true;
        }

        if (touchedTrigger)
        {
            Invoke("SpotLightFunction", timeBeforeDimmingDownInSec);

            Debug.Log("Trigger-box touched"); //test
            gameObject.GetComponent<Collider>().enabled = false; //so that we can't activate it more then once - not necessary due to lightGoesOn bool, but maybe later will be needed
        }
    }

    void AnimationFunction()
    {
        Debug.Log("AnimationStart");

        foreach (GameObject door in doors)
        {
            if(door.transform.position.y <= endYpositon)
            {
                door.transform.position += new Vector3(0, stepsToMove, 0);
            }
        }
    }

    void SpotLightFunction()
    {
        Debug.Log("Spotlights will be activated");
        if (lightIntesityValue < maxLightIntesity && lightGoesOn)
        {
            lightIntesityValue += stepsItWillTakeUntilLightIsOnOrOff;
        }
        else
        {
            AnimationFunction(); // if the light is on, start animation
            Invoke("MakeLightNormal", timeBeforeDimmingDownInSec);
        }

        foreach (Light light in spotLights)
        {
            light.intensity = lightIntesityValue; //set the intensity
        }
    }
    void MakeLightNormal()
    {
        lightGoesOn = false;
        if (lightIntesityValue > minLightIntesity) lightIntesityValue -= stepsItWillTakeUntilLightIsOnOrOff; //here we would need a new float if we want to have a slower/faster time to turn off lights
    }
}
