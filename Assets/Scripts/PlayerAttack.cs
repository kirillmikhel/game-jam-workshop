using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool active = false;
    public int damage = 1;
    public float cooldown = 0.6f;

    private Animator _animator;
    private CircleCollider2D _attackZone;
    private SoundController _soundController;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _attackZone = GetComponent<CircleCollider2D>();
        _soundController = GameManager.Instance.GetComponent<SoundController>();
    }

    public void DoAttack()
    {
        if (active) return;

        active = true;

        StartCoroutine(Perform());
    }

    private IEnumerator Perform()
    {
        _soundController.Play("Swing");

        _animator.SetTrigger("Attack");

        _attackZone.enabled = true;

        yield return new WaitForSeconds(cooldown);

        _attackZone.enabled = false;

        active = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>()?.ReceiveDamage(damage);
    }
}