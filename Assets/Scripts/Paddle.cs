using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{


    public Rigidbody2D rb { get; private set; }
    public Vector2 direction { get; private set; }

    public float speed = 30f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if(this.direction != Vector2.zero)
        {
            this.rb.AddForce(this.direction*this.speed);
        } 

    }
}
