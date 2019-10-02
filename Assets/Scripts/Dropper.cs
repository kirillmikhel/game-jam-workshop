using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject[] prefabs;

    public void Drop()
    {
        var randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

        var droppedItem = Instantiate(randomPrefab, transform.position, Quaternion.identity);

        //droppedItem.transform.SetParent(null);
    }
}
