using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour

{
    public KeyCode key;
    public bool stop;
    public GameObject menu;
    public bool canActivate;

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (canActivate)
            {
                if (stop == true)
                {
                    menu.SetActive(false);
                    Time.timeScale = 1;
                    stop = false;
                }
                else
                {
                    menu.SetActive(true);
                    Time.timeScale = 0;
                    stop = true;
                }
            }
            
        }
    }
}
