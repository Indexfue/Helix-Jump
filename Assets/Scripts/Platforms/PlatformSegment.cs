using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Break(Vector3 breakPoint, float breakForce, float breakRadius)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(breakForce, breakPoint, breakRadius);
    }
}
