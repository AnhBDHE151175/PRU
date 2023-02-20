using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }


    const string ScorePrefix = "Score: ";
    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += LoadScene;

    }
    private void LoadScene(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();

    }
    void Start()
    {
        StartGame();
        EventManager.AddEventListener(AddPoints);
    }

    void Update()
    {

    }

    public void StartGame()
    {
        this.score = 0;
        this.lives = 3;
        SetLevel(level);
    }
    public void SetLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level " + level);
    }
    public void AddPoints(int points)
    {
        score += points;
        //scoreText.text = ScorePrefix + score;
        if (IsClear())
        {
            SetLevel(level + 1);
        }
    }
    public void MissBall()
    {
        lives--;
        if (lives > 0)
        {
            ResetLevel();
        }
        else if (lives == 0)
        {
            GameOver();
        }
    }
    private void ResetLevel()
    {
        this.ball.ResetPosition();
        this.paddle.ResetPosition();
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        //StartGame();
    }
    private bool IsClear()
    {
        foreach (var item in bricks)
        {
            if (item.gameObject.activeInHierarchy && !item.unBreak)
            {
                return false;
            }
        }
        return true;
    }




}
