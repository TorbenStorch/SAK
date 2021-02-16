/// P3 Swiss Army Knife project
/// Torben Storch
/// Group 2 (Iman, Namgar, Torben)
/// Summary: 
/// 1) Responsible for switching the scenes from transition-room to adventure
/// 2) Has to be connceted with the door and its interaction-component -> when user hovers over door-handle, controller button gets shown and when pressed, the scene changes


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class DoorSceneSwitch : MonoBehaviour
{
    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    void OnHandHoverBegin(Hand hand)
    {
        Debug.LogWarning("Door Touched");
        hand.ShowGrabHint();
    }

    void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();

        if (grabType != GrabTypes.None)
        {
            Debug.LogWarning("SceneSwitch");
            Invoke("SwitchScene", 0.4f);
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}

