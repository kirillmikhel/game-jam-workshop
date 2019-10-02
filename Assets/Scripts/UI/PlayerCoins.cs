using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoins : MonoBehaviour
{
    public Sprite[] sprites;
        
    private Image _image;
    private GameObject _player;
    private Inventory _playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerInventory = _player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        var coins = _playerInventory.coins;

        _image.sprite = sprites[coins];
    }
}
