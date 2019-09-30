using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 6;
    public int maxHP = 6;

    public void Increment()
    {
        HP = Mathf.Min(maxHP, HP + 1);
    }
}