using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight_Con : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // get mouse position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); // calculate mosue position from screen position to world position

        transform.position = new Vector2(mousePos.x, mousePos.y); // change this gameobject position to mouse position
    }
}
