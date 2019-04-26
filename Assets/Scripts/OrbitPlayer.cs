using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float orbitDistance;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    void FixedUpdate()
    {
        transform.position = target.position + (transform.position - target.position).normalized * 1.5f;
        transform.RotateAround(target.position, zAxis, speed);
    }
}
