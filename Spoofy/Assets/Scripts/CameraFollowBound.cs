﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBound : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 Offset;

    private void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return;
        }

        Vector3 Centerpoint = GetCenterPoint();

        Vector3 newPosition = Centerpoint + Offset;
        transform.position = newPosition;
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }


}
