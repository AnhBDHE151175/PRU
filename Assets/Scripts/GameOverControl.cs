using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    public TextMeshProUGUI yourScore;

    private void Start()
    {
        yourScore.text = "Your score: " + Level3GameManager.Scores;
    }
}
