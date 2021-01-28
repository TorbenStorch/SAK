using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLine1 : MonoBehaviour
{
    //public GameObject player; //have to figure out how to find player-collider and then replace it with it
    public bool crossedTriggerLine = false; // for now this is public - just for debug options
    public Transform player;


    //for spotlights
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

    //for animation
    [Header("Animation")]
    public bool startSAKAppearAnimation = false;
    //here will be the data for the animation part

    //for music/sound
    [Header("Music and Sound")]
    public bool startTheSAKAppearAudio = false;
    //here will be the data for the audio part

    void Awake()
    {
        if (allSpotlights == null) Debug.LogError("No Parent for spotlights connected");
        spotLights = allSpotlights.GetComponentsInChildren<Light>();
    }
    private void Start()
    {
        lightIntesityValue = minLightIntesity;
        foreach (Light light in spotLights)
        {
            light.intensity = lightIntesityValue;
        }
    }
    /*private void OnTriggerEnter(Collider other) //use that later to activate all stuff
    {
        if (other == colliderObj)
        {
            crossedTriggerLine = true;
        }
    }*/

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || player.position.z < transform.position.z) //just to test
        {
            crossedTriggerLine = true;
        }

        if (crossedTriggerLine)
        {
            SpotLightFunction(); //here is the whole code that modifies the light
            AnimationFunction();
            AudioFunction();

            Debug.Log("Trigger line crossed"); //test
            gameObject.GetComponent<Collider>().enabled = false; //so that we can't activate it more then once - not necessary due to lightGoesOn bool, but maybe later will be needed
        }
    }

    void AnimationFunction()
    {
        startSAKAppearAnimation = true;
        Debug.Log("SAK appear animation can start");
    }
    void AudioFunction()
    {
        startTheSAKAppearAudio = true;
        Debug.Log("SAK appear audio can start");
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

