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

    private ImmuneUntil _immuneUntil;

    private void Start()
    {
        _immuneUntil = GetComponent<ImmuneUntil>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_immuneUntil && _immuneUntil.IsImmune()) return;

        other.GetComponent<Collector>()?.Collect(this);
    }
}