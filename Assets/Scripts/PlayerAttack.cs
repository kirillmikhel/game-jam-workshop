using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float cooldown = 1.0f;

    private float _currentCooldown = 0;
    private Animator _animator;
    private CircleCollider2D _circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    public void DoAttack()
    {
        if (_currentCooldown > 0) return;

        GameManager.Instance.GetComponent<SoundController>().swingCollectSource.Play();

        _animator.SetTrigger("Attack");
        _animator.speed = 1;

        _currentCooldown = cooldown;

        StartCoroutine(ActivateAttackZone());
    }

    private IEnumerator ActivateAttackZone()
    {
        _circleCollider2D.enabled = true;

        yield return new WaitForSeconds(0.3f);

        _circleCollider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Health>()?.ReceiveDamage(damage);
    }
}