using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    public int targetFps;
    
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFps;
    }
}
