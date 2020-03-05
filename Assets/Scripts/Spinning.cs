using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float angularSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * angularSpeed);
    }
}