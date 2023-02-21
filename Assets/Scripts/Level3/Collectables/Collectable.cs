using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            this.ApplyEffect();
        }

        if (collision.gameObject.tag == "Paddle" || collision.gameObject.tag == "DeathCollider")
        {
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect();
}
