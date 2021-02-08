using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Teleporter : MonoBehaviour
{
    TeleportPosition[] positions;
    void Start()
    {
        // finding objects positions
        positions = GameObject.FindObjectsOfType<TeleportPosition>();
        //sorting indexes & store it in new array
        positions = positions.OrderBy(position => position.index).ToArray();
        // initialize camera position
        transform.position = positions.First(position => position.initial == true).transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            transform.position = positions[0].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            transform.position = positions[1].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            transform.position = positions[2].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            transform.position = positions[3].transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            transform.position = positions[4].transform.position;
        }
    }
}
