using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;
    public List<string> tagsToIgnore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsToIgnore.Count > 0 && tagsToIgnore.Contains(other.tag)) return;

        other.GetComponent<Health>()?.ReceiveDamage(damage);

        Destroy(gameObject);
    }
}