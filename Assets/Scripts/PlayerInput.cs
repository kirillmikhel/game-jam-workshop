using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement _movement;
    private PlayerAttack _playerAttack;
    private Defence _defence;

    // Start is called before the first frame update
    void Start()
    {
        _defence = GetComponent<Defence>();
        _movement = GetComponent<Movement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDirections();
        HandleAttack();
        HandleShield();
    }

    private void HandleDirections()
    {
        if (!_movement) return;

        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_playerAttack.active) direction = Vector2.zero;
        if (_defence.isActive && direction != Vector2.zero) _defence.SetDirection(direction);

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

    private void HandleShield() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _defence.Enable();
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _defence.Disable();
        }
    }
}