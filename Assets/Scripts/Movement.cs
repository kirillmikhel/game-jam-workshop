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

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction * speed;

        //_animator.speed = direction == Vector2.zero ? 0 : 1;

        _animator.SetFloat("Velocity", direction.magnitude);

        if (direction == Vector2.zero) return;

        _animator.SetFloat("Horizontal Direction", direction.x);
        _animator.SetFloat("Vertical Direction", direction.y);
    }
}