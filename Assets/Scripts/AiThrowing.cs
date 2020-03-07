using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiThrowing : MonoBehaviour
{
    public float throwingInterval = 1.5f;

    private Throwing _throwing;

    // Start is called before the first frame update
    void Start()
    {
        _throwing = GetComponent<Throwing>();

        if (!_throwing) return;

        Coroutine coroutine = null;

        GetComponentInChildren<Detector>().onDetect +=
            detected => coroutine = StartCoroutine(DoThrowing(detected.transform));

        GetComponentInChildren<Detector>().onOutOfSight +=
            detected => StopCoroutine(coroutine);
    }

    private IEnumerator DoThrowing(Transform target)
    {
        while (true)
        {
            StartCoroutine(_throwing.Perform(target));

            yield return new WaitForSeconds(throwingInterval);
        }
    }
}