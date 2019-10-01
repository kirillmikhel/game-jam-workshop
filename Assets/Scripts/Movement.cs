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
        _rigidbody.velocity = direction.normalized * speed;

        _animator.speed = direction == Vector2.zero ? 0 : 1;

        _animator.SetFloat("Walk right", direction.x);
        _animator.SetFloat("Walk left", -direction.x);
        _animator.SetFloat("Walk up", direction.y);
        _animator.SetFloat("Walk down", -direction.y);
    }
}