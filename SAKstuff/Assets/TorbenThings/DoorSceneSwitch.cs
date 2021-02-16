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
            Invoke("SwitchScene", 0.5f);
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}

