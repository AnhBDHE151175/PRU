using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    #region Singleton
    private static PaddleManager _instance;
    public static PaddleManager Instance => _instance;

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
    private Camera mainCamera;
    private float paddleInititalY;
    private float defaultPaddleWidthInPixels = 200;
    public float defaultLeftClamp = 105;
    public float defaultRightClamp = 720;
    private SpriteRenderer sr;
    private BoxCollider2D boxCol;
    public bool isExtend;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        paddleInititalY = transform.position.y;
        sr = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        isExtend = false;   
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        float paddleShift = (defaultPaddleWidthInPixels - defaultPaddleWidthInPixels / 2 * sr.size.x) / 2;
        float leftClamp = defaultLeftClamp - paddleShift;
        float rightClamp = defaultRightClamp + paddleShift;
        float mousePositionPixels = Mathf.Clamp(Input.mousePosition.x, leftClamp, rightClamp);
        float mousePositionX = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionPixels, 0, 0)).x;
        transform.position = new Vector3(mousePositionX, paddleInititalY, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var paddlePos = gameObject.transform.position;
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = collision.contacts[0].point;
            Vector3 paddleCenter = new Vector3(paddlePos.x, paddlePos.y);

            ballRb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;
            if(hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector2( -(Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
            }
            else
            {
                ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
            }
        }
    }

    public void StartAnimation(float addWidth)
    {
        /*StartCoroutine(AnimatePaddleWidth(newWidth));*/
        if((addWidth < 0 && isExtend) || (addWidth > 0 && !isExtend))
        {
            var currentScale = gameObject.transform.localScale;
            gameObject.transform.localScale = Vector3.Lerp(currentScale, currentScale + new Vector3(addWidth, 0, 0), Time.deltaTime * 3);
            boxCol.size = Vector2.Lerp(boxCol.size, boxCol.size + new Vector2(addWidth, 0), Time.deltaTime * 3);
            isExtend = !isExtend;
        }

    }
}

