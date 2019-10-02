using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool isGameOn = false;

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

    public void StartTheGame()
    {
        Instance.isGameOn = true;

        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void Restart()
    {
        Instance.isGameOn = false;
        SceneManager.LoadScene("Menu");
    }

    public static void TriggerVictory()
    {
        Instance.isGameOn = false;
        SceneManager.LoadScene("Victory");
    }

    public static void TriggerGameOver()
    {
        Instance.isGameOn = false;
        SceneManager.LoadScene("GameOver");
    }
}
