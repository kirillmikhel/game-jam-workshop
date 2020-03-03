using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement _movement;
    private PlayerAttack _playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDirections();
        HandleAttack();
    }

    private void HandleDirections()
    {
        if (!_movement) return;

        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _movement.Move(direction.normalized);
    }

    private void HandleAttack()
    {
        if (!_playerAttack) return;

        if (Input.GetAxisRaw("Attack") == 1)
        {
            _playerAttack.DoAttack();
        }
    }
}