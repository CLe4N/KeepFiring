using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    string sceneName;
    AudioSource gameOverBGM;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name; // get active scene name
        gameOverBGM = GetComponent<AudioSource>(); // access AudioSource component
        gameOverBGM.Play(); // play"gameOverBGM"
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName); // load this scene
        Time.timeScale = 1; // timescale = 1
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene"); // load menu scene
        Time.timeScale = 1; // timescale = 1
    }

}
