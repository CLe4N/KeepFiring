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
        sceneName = SceneManager.GetActiveScene().name;
        gameOverBGM = GetComponent<AudioSource>();
        gameOverBGM.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
    }

}
