using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rot : MonoBehaviour
{
    void Update()
    {
        LookAt_Pos(); //call "LookAt_Pos" method
    }

    void LookAt_Pos()
    {
        Vector3 mousePos = Input.mousePosition; //Get mouse position 
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); // calculate mouse position form main camera screen to world point

        Vector2 direction = new Vector2 // Calculate this gameobject position and "main-cam view mouse position" to find direction 
            (mousePos.x - transform.position.x, 
             mousePos.y - transform.position.y);

        transform.up = direction; //rotate to "direction"'s direction 
    }
}
