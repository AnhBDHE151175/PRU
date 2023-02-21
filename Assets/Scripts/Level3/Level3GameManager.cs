using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3GameManager : MonoBehaviour
{
    #region Singleton
    private static Level3GameManager _instance;
    public static Level3GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    public int TotalLives { get; set; } = 3;
    public int Lives { get; set; }
    public static int Scores { get; set; }


    public static HashSet<int> Records { get; set; } = new HashSet<int>
        {
            50, 100, 70
        };
    public bool IsGameStarted { get; set; }

    public TextMeshProUGUI textLives;
    public TextMeshProUGUI textScore;
    private void Start()
    {
        Lives = TotalLives;
        Ball2.OnBallDestroy += OnBallDestroy;
        Brick2.OnBrickDestruction += OnBrickDestruction;
        textLives.text = $"Lives: {Lives}";
        textScore.text = $"Scores: {Scores}";
    }
    private void Update()
    {
        textScore.text = $"Scores: {Scores}";
        var remainBrick = GameObject.FindGameObjectsWithTag("SingleBrick");
        if (remainBrick.Count() == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    private void OnBallDestroy(Ball2 ball)
    {
        if (BallManager.Instance.Balls.Count <= 0)
        {
            this.Lives--;
            if (this.Lives < 1)
            {
                //End game
                Records.Add(Scores);
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                BallManager.Instance.InitBall();
                IsGameStarted = false;
                textLives.text = $"Lives: {Lives}";
                textScore.text = $"Scores: {Scores}";

            }
        }
    }

    private void OnBrickDestruction(Brick2 brick)
    {

    }
}
