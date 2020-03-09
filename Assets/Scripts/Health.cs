using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 1;
    public int maxHP = 1;

    private SpriteRenderer _spriteRenderer;
    private Dropper _dropper;

    private void Awake()
    {
        _dropper = GetComponent<Dropper>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Increment()
    {
        HP = Mathf.Min(maxHP, HP + 1);
    }

    public void ReceiveDamage(int damage)
    {
        HP = Mathf.Max(HP - damage, 0);

        GameManager.Instance.GetComponent<SoundController>().Play("Hit");

        var coroutine = StartCoroutine(DisplayDamage());

        if (HP > 0) return;

        StopCoroutine(coroutine);
        Invoke(nameof(Die), 0.05f);
    }

    private IEnumerator DisplayDamage()
    {
        var initialColor = _spriteRenderer.color;

        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.25f);

        _spriteRenderer.color = initialColor;
    }

    private void Die()
    {
        if (_dropper) _dropper.Drop();

        Destroy(gameObject);
    }
}