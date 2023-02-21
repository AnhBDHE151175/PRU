using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    #region Singleton
    private static BallManager _instance;
    public static BallManager Instance => _instance;

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

    [SerializeField]
    public Ball2 ballPrefab;
    private Ball2 initialBall;
    private Rigidbody2D initialBallRb;

    public float initialBallSpeed = 1000;
    public List<Ball2> Balls { get; set; }

    private void Start()
    {
        InitBall();
    }
    private void Update()
    {
        if (!Level3GameManager.Instance.IsGameStarted)
        {
            Vector3 paddlePosition = PaddleManager.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 1.7f, 0);
            initialBall.transform.position = ballPosition;

            if (Input.GetMouseButton(0))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.AddForce(new Vector2(0, initialBallSpeed));
                Level3GameManager.Instance.IsGameStarted = true;
            }
        }
    }
    public void InitBall()
    {
        Vector3 paddlePosition = PaddleManager.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y + 1.7f, 0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball2>
        {
            initialBall
        };

    }
    public void SpawnBalls(Vector3 position, int count)
    {
        if (Balls.Count > 500)
        {
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Ball2 spawnBall = Instantiate(ballPrefab, position, Quaternion.identity) as Ball2;
            Rigidbody2D spawnedBallRb = spawnBall.GetComponent<Rigidbody2D>();
            spawnedBallRb.isKinematic = false;
            spawnedBallRb.AddForce(new Vector2(0.5f, initialBallSpeed));
            this.Balls.Add(spawnBall);
        }
    }
}
