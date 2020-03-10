using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    public GameObject shield;
    public bool isActive = false;
    private Vector2 _offset;

    public void Enable() {
        isActive = true;
        shield.SetActive(true);
    }

    public void Disable() {
        isActive = false;
        shield.SetActive(false);
    }

    public void SetDirection(Vector2 direction) {
        Debug.Log(direction);
        _offset = direction;
        shield.transform.position = new Vector3(transform.position.x - -0.2f * direction.x, transform.position.y - -0.2f * direction.y - 0.01f, shield.transform.position.z);
    }
}
