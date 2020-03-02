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
                soundController.coinCollectSource.Play();
                GetComponent<Inventory>().coins++;
                break;
            case CollectableType.HealthKit:
                soundController.healthCollectSource.Play();
                GetComponent<Health>().Increment();
                break;
            default:
                return;
        }

        Destroy(item.gameObject);
    }
}