/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for activating spotlights and creating animations for the doors, 
/// 2) Has to be connceted with the giant SAK & its Interaction component(when its touched the actions will be invoked), doors to move, spotlights to adjust

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SAKTriggerBox : MonoBehaviour
{
    public bool touchedTrigger = false;

    private Interactable interactable;

    [Header("Spotlights")]
    public GameObject allSpotlights; //we need ONE parent GameObject with all spotlights inside
    Light[] spotLights;

    private float lightIntesityValue; //value of the intenity
    private bool lightGoesOn = true; //this is true if the lights are not dimming down

    //here we can adjust everything in the implementation phase
    public float maxLightIntesity = 1.3f; //could be lower - should not be higher then 1.3f
    public float minLightIntesity = 0.5f; //maybe set that to 0f if we don't want light from the beginning?
    public float timeToStartSpotlightsInSec = 10f;
    public float timeBeforeDimmingDownInSec = 5f;
    public float stepsItWillTakeUntilLightIsOnOrOff = 0.005f; //the lower the longer - if we want seperat times for start/end, we need two floats instead of one OR divide/multiply the value

    [Header("Door Animation")]
    public float timeBeforeDoorAnim = 1.0f;
    public float stepsToMove = 0.1f;
    public float startYposition = 0.75f; //in this test the doors are closed at 0.75f - maybe different
    public float endYpositon = 2.1f; //in this test the doors are open at 2.1f - maybe different
    GameObject[] doors;

    void Awake()
    {
        if (allSpotlights == null) Debug.LogError("No Parent for spotlights connected");
        spotLights = allSpotlights.GetComponentsInChildren<Light>();

        doors = GameObject.FindGameObjectsWithTag("MoveDoor");
        if (doors == null) Debug.LogError("No doors found");
    }
    private void Start()
    {
        interactable = GetComponent<Interactable>();
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

    void OnHandHoverBegin() //if hand hovers over -> touched SAK    
    {
        Debug.LogWarning("Tocuhed");
        touchedTrigger = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //just to Debug
        {
            touchedTrigger = true;
        }

        if (touchedTrigger)
        {
            Invoke("SpotLightFunction", timeToStartSpotlightsInSec);
            Invoke("AnimationFunction", timeBeforeDoorAnim);
            Debug.Log("Trigger-box touched");
        }
    }

    void AnimationFunction()
    {
        Debug.Log("AnimationStart");

        foreach (GameObject door in doors)
        {
            if(door.transform.position.y <= endYpositon)
            {
                door.transform.position += new Vector3(0, stepsToMove * Time.deltaTime, 0);
            }
        }
    }

    void SpotLightFunction()
    {
        Debug.Log("Spotlights will be activated");
        if (lightIntesityValue < maxLightIntesity && lightGoesOn)
        {
            lightIntesityValue += stepsItWillTakeUntilLightIsOnOrOff * Time.deltaTime;
        }
        else
        {
            //AnimationFunction(); // if the light is on, start animation
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
        if (lightIntesityValue > minLightIntesity) lightIntesityValue -= stepsItWillTakeUntilLightIsOnOrOff * Time.deltaTime; //here we would need a new float if we want to have a slower/faster time to turn off lights
    }
}
