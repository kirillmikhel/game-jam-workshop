using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public void Collect(Collectable item)
    {
        var soundController = GameManager.Instance.GetComponent<SoundController>();

        switch (item.type)
        {
            case CollectableType.Coin:
                soundController.Play("Coin");
                GetComponent<Inventory>().coins++;
                break;
            case CollectableType.HealthKit:
                soundController.Play("Health kit");
                GetComponent<Health>().Increment();
                break;
            default:
                return;
        }

        Destroy(item.gameObject);
    }
}