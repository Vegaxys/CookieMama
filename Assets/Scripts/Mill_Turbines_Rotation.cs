﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill_Turbines_Rotation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }
}
