using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    public GameObject canvas;
    public bool isActive;
    public StopBall ball;
    
    public void Mask()
    {
        if (isActive)
        {
            ball.canActivate = false;
            canvas.SetActive(true);
        }
        else
        {
            ball.canActivate = true;
            canvas.SetActive(false);
        }
    }
}
