using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour
{
    public int damage = 1;
    public float cooldown = 1.0f;
    
    private float _currentCooldown = 0;

    void Update()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || _currentCooldown > 0) return;
        
        other.gameObject.GetComponent<Health>().ReceiveDamage(damage);

        _currentCooldown = cooldown;
    }
}