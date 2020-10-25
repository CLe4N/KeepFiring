using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailUi : MonoBehaviour
{
    public GameObject PlayerUi;
    public GameObject ScoreUi;
    public GameObject Spawner;

    private void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            Time.timeScale = 1;
            PlayerUi.SetActive(true);
            ScoreUi.SetActive(true);
            Spawner.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
