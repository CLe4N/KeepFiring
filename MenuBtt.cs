using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBtt : MonoBehaviour
{
    public Text HighScore; //Create public Text variable 
    public Save_Con HighScoreData; //Create public Save_Con variable 
    void Update()
    {
        if(HighScoreData.data.high_score >= 999999) // condition HighScoreData.data.high_score is >= 999999
        {
            HighScore.text = "MAX!!!"; //if true, change HighScore's text to "MAX!!!"
        }
        else
        {
            HighScore.text = HighScoreData.data.high_score.ToString(); // if not, change HighScore's text to value in HighScoreData.data.high_score
        }
    }
    public void Start_Btt()
    {
        SceneManager.LoadScene("PlayScene"); //load "PlayScene" scene
    }

    public void Exit()
    {
        Application.Quit(); //Exit the application
    }
}
