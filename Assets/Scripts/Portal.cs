using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal exitPortal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || exitPortal != null) return;

        var deltaPosition = transform.position - other.transform.position;

        other.transform.position = exitPortal.transform.position - deltaPosition;
    }
}