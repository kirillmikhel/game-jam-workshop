using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public delegate void DetectionDelegate(GameObject detected);

    public DetectionDelegate onDetect;
    public DetectionDelegate onOutOfSight;

    public float range = 1.0f;
    public List<string> tagsToDetect;

    private List<GameObject> _detected;
    private CircleCollider2D _detectionCollider;

    // Start is called before the first frame update
    void Start()
    {
        _detected = new List<GameObject>();

        _detectionCollider = gameObject.AddComponent<CircleCollider2D>();
        _detectionCollider.isTrigger = true;
        _detectionCollider.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tagsToDetect.Count > 0 && !tagsToDetect.Contains(other.tag)) return;

        if (_detected.Contains(other.gameObject)) return;

        _detected.Add(other.gameObject);

        onDetect?.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (tagsToDetect.Count > 0 && !tagsToDetect.Contains(other.tag)) return;

        if (!_detected.Contains(other.gameObject)) return;

        _detected.Remove(other.gameObject);

        onOutOfSight?.Invoke(other.gameObject);
    }
}