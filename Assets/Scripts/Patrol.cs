using System;
using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public bool vertical = false;
    public bool inverse = false;

    private Movement _movement;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();

        if (_movement) StartCoroutine(DoPatrol());
    }

    private IEnumerator DoPatrol()
    {
        var direction = vertical ? Vector2.up : Vector2.left;

        if (inverse)
        {
            direction = -direction;
        }

        while (true)
        {
            yield return new WaitForSeconds(2);

            _movement.Move(direction);

            direction = -direction;
        }
    }
}