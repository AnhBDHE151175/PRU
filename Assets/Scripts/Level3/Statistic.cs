using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Profiling;

public class Statistic : MonoBehaviour
{
    public TextMeshProUGUI Top1_Score;
    public TextMeshProUGUI Top2_Score;
    public TextMeshProUGUI Top3_Score;
    private void Start()
    {
        LoadStatistic();
    }

    private void LoadStatistic()
    {
        var data = Level3GameManager.Records.OrderByDescending(x => x).Take(3).ToList();
        for(int i = 0; i < data.Count(); i++)
        {
            switch (i + 1)
            {
                case 1:
                    Top1_Score.text = data[i].ToString();
                    break;
                case 2:
                    Top2_Score.text = data[i].ToString();
                    break;
                case 3:
                    Top3_Score.text = data[i].ToString();
                    break;
            }
        }
        
    }
}
