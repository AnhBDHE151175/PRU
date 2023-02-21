using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    #region Singleton
    private static BrickManager _instance;
    public static BrickManager Instance => _instance;

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

    public Sprite[] sprites;
    public AudioSource breakBrick;
    public AudioSource onReach;

    public List<Brick> Bricks { get; private set; }
}
