using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZIndex : MonoBehaviour
{
    void Awake()
    {
        SetZPosition();
    }

    void Update()
    {
        SetZPosition();
    }

    private void SetZPosition()
    {
        var position = transform.position;

        position.z = position.y;

        transform.position = position;
    }
}