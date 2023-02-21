using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    public static event Action<Ball2> OnBallDestroy;

    public void Die()
    {
        OnBallDestroy?.Invoke(this);
        Destroy(gameObject);
    }
}
