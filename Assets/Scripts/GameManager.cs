using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        StartGame();
    }

    void Update()
    {

    }

    public void StartGame()
    {
        this.score = 0;
        this.lives = 3;
        SetLevel(1);
    }
    public void SetLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level " + level);
    }
}
