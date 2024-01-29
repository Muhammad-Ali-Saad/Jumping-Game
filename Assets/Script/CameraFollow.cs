using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.25f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)  // Check if the target is not null
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
            transform.position = smoothPosition;
        }
    }
}
