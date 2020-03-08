using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimeout : MonoBehaviour
{
    public float timeout = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(Destroy), timeout);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}