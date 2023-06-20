using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TODO: NAMESPACES
public class Ball : MonoBehaviour
{
    public static event UnityAction Triggered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlatformSegment>(out PlatformSegment platformSegment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }
}
