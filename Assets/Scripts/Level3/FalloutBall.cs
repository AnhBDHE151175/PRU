using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Ball2 ball = collision.gameObject.GetComponent<Ball2>();
            BallManager.Instance.Balls.Remove(ball);
            ball.Die();
        }
    }
}
