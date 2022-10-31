using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyFollow : MonoBehaviour
{
    Rigidbody rb;
    [Range(0.1f, 1f)]
    public float Smooth;
    public GameObject target;
    private bool isTouchEnemy;
    private bool isTouchFuel;
    public bool EngineStopped;

    public static RigidBodyFollow instance;

    public Vector3 storedVelocity;

    public LayerMask WhatIsSolid;
    public string WhatIsFuel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EngineStopped == false)
        {
            storedVelocity = rb.velocity;
            rb.MovePosition(Vector3.Lerp(transform.position, target.transform.position, Smooth));
            if (rb.velocity.magnitude > 0.1f)
            {
                rb.MoveRotation(Quaternion.Lerp(transform.rotation, target.transform.rotation, Smooth));
            }
        }
        else
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.4f);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(WhatIsFuel))
        {
            GameMechanics.instance.Fuel = other.gameObject.GetComponent<RandomFuel>().CalculateFuel(GameMechanics.instance.Fuel);
        }
    }
}
