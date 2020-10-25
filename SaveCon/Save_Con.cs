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
        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/Game.dat";
        Debug.Log(dataFilePath);
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (SaveData)bf.Deserialize(fs);
            fs.Close();
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
        if (playerScore != null)
        {
            if (playerScore.ScorePoint > data.high_score)
            {
                if(HighScore != null)
                {
                    HighScore.SetActive(true);
                }
                data.high_score = playerScore.ScorePoint;
            }
        }
    }
}
