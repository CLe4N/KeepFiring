﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(this.gameObject); // destroy this gameobject
    }
}
