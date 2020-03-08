using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool active = false;
    public int damage = 1;
    public float cooldown = 0.4f;

    private Animator _animator;
    private CircleCollider2D _attackZone;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackZone = GetComponent<CircleCollider2D>();
    }

    public IEnumerator DoAttack()
    {
        if (active) yield break;

        GameManager.Instance.GetComponent<SoundController>().Play("Swing");

        _animator.SetTrigger("Attack");

        active = true;
        _attackZone.enabled = true;

        yield return new WaitForSeconds(cooldown);

        active = false;
        _attackZone.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>()?.ReceiveDamage(damage);
    }
}