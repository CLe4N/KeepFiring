using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight_Con : MonoBehaviour
{

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = new Vector2(mousePos.x, mousePos.y);
    }
}
