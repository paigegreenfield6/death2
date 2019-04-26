using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementMovement : MonoBehaviour
{

    public bool leave;
    // Start is called before the first frame update
    void Start()
    {
        leave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (leave)
        {
            transform.Translate(Vector3.up * 0.03f, Space.World);
        }

    }
}
