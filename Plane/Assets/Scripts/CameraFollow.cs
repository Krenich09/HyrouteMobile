using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera cam;
    [Header("Follow")]
    public Transform target;
    [Range(0.01f, 1f)] public float smoothSpeed;
    public Vector3 offset, rotationOffset;
    private Vector3 velocity = Vector3.zero;


    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!GameMechanics.instance.GameLost)
        {
            Vector3 desiredPostion = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPostion, ref velocity, smoothSpeed);

            transform.LookAt(target.position + rotationOffset);

        }

    }
}
