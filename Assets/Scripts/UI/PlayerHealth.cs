using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private RectTransform _rectTransform;
    private GameObject _player;
    private Health _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<Health>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rectTransform) return;
        
        _rectTransform.sizeDelta = new Vector2(_playerHealth.HP * 64, 64);
    }
}