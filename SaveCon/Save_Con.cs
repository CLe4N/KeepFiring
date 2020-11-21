using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class Save_Con : MonoBehaviour
{
    public SaveData data;
    public Score playerScore;
    public GameObject HighScore;
    string dataFilePath;
    BinaryFormatter bf;

    void Awake()
    {
        bf = new BinaryFormatter(); // bf = empty BinaryFormatter
        dataFilePath = Application.persistentDataPath + "/Game.dat"; //  set destination of save path to system folder
        Debug.Log(dataFilePath); // show save path log
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create); // create file on system folder
        bf.Serialize(fs, data); // Serialize file value
        fs.Close(); // close flie
    }
    public void LoadData()
    {
        if (File.Exists(dataFilePath)) // do if file is already exit in system folder
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open); // open file
            data = (SaveData)bf.Deserialize(fs); // Deserialize file value and get value
            fs.Close(); // close file
        }
    }

    private void OnEnable()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void Update()
    {
        if (playerScore != null) // do if score not empty
        {
            if (playerScore.ScorePoint > data.high_score) // do if player score is more than high score value
            {
                if(HighScore != null) // do if high score not empty
                {
                    HighScore.SetActive(true); // active high score ui 
                }
                data.high_score = playerScore.ScorePoint; // high score value equal player score
            }
        }
    }
}
