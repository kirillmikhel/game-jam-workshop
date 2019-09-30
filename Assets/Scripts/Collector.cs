using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public void Collect(Collectable item)
    {
        switch (item.type)
        {
            case CollectableType.Coin:
                GetComponent<Inventory>().coins++;
                break;
            case CollectableType.HealthKit:
                GetComponent<Health>().Increment();
                break;
            default:
                return;
        }

        Destroy(item.gameObject);
    }
}