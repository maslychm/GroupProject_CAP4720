﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFramerate : MonoBehaviour
{
    public int target = 60;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
    
    void Update()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
    }
}
