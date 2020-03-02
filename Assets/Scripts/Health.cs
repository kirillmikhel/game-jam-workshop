using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 1;
    public int maxHP = 1;

    public void Increment()
    {
        HP = Mathf.Min(maxHP, HP + 1);
    }

    public void ReceiveDamage(int damage)
    {
        HP = Mathf.Max(HP - damage, 0);

        GameManager.Instance.GetComponent<SoundController>().hitCollectSource.Play();

        if (HP > 0) return;

        GetComponent<Dropper>()?.Drop();
        Destroy(gameObject);
    }
}