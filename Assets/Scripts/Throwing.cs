using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Throwing : MonoBehaviour
{
    public bool active = false;
    public GameObject prefab;
    public float speed = 4.0f;
    public float cooldown = 1.0f;

    public IEnumerator Perform(Transform target)
    {
        if (active) yield break;

        active = true;

        var stone = Instantiate(prefab, transform);
        stone.transform.position = transform.position;
        stone.transform.SetParent(GameObject.Find("Stones").transform);

        var direction = (target.position - transform.position).normalized;

        stone.GetComponent<Rigidbody2D>().velocity = direction * speed;

        yield return new WaitForSeconds(cooldown);

        active = false;
    }
}