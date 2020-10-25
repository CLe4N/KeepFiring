using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ScorePoint;
    public Text PointText;
    void Start()
    {
        ScorePoint = 0;
    }

    void Update()
    {
        PointText.text = ScorePoint.ToString();
    }
}
