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
        Time.timeScale = 0; // stop time
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) // if left or right mouse is click
        {
            Time.timeScale = 1; // time start
            PlayerUi.SetActive(true); // active PlayerUI
            ScoreUi.SetActive(true); // active ScoreUi
            Spawner.SetActive(true); //  active Spawner
            Destroy(this.gameObject); // destroy this gameobject
        }
    }
}
