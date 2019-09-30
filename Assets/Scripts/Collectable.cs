using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Coin,
    HealthKit
}

public class Collectable : MonoBehaviour
{
    public CollectableType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Collector>()?.Collect(this);
    }
}