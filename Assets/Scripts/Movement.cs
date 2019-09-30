using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.0f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!_rigidbody) return;

        Vector2 direction = Vector2.zero;

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            direction += Vector2.up * speed;
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            direction += Vector2.down * speed;
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            direction += Vector2.right * speed;
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            direction += Vector2.left * speed;
        }


        _rigidbody.velocity = direction.normalized * speed;

        _animator.speed = direction == Vector2.zero ? 0 : 1;
    }
}