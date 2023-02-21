using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Sprite[] sprites;
    public int health { get; private set; }
    public int pointUnit = 100;

    public bool unBreak;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (!unBreak)
        {
            health = sprites.Length;
            spriteRenderer.sprite = sprites[health - 1];
        }
    }

    void Update()
    {
        
    }

    private void Hit()
    {
        if (unBreak)
        {
            return;
        }
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);

        }
        else
        {
            spriteRenderer.sprite = sprites[health - 1];
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}
