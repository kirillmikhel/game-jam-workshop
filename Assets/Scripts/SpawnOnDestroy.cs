using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject prefab;

    private void OnDestroy()
    {
        var obj = Instantiate(prefab, transform.position, Quaternion.identity);

        obj.transform.SetParent(null);
    }
}