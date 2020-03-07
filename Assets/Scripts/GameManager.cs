using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Exit();
        }
    }

    private void Exit()
    {
        Application.Quit();
    }

    private static void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}