using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmuneUntil : MonoBehaviour
{
    public float immunityTimeout = 1.0f;

    private float _timeLeft = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = immunityTimeout;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
    }

    public bool IsImmune()
    {
        return _timeLeft > 0;
    }
}
