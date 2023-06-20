using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _breakForce;
    [SerializeField] private float _breakRadius;

    private void OnEnable()
    {
        Ball.Triggered += Break;
    }

    private void OnDisable()
    {
        Ball.Triggered -= Break;
    }

    public void Break()
    {
        PlatformSegment[] segments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in segments)
        {
            segment.Break(transform.position, _breakForce, _breakRadius);
        }
    }
}
