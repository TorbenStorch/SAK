using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetector : MonoBehaviour
{
    public CapsulePosition Capsule;

    private void OnTriggerEnter(Collider other)
    {
        Capsule.activate = true;
    }
}
