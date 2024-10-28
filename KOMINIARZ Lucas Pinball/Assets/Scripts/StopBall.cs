using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour

{
    [SerializeField] KeyCode key;
    public bool stop;
    [SerializeField] GameObject menu;
    public bool canActivate;
    [SerializeField] private UiManager uiManagerReference;
    

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (canActivate)
            {
                if (stop == true)
                {
                    uiManagerReference.GameState(3);
                    stop = false;
                }
                else
                {
                    uiManagerReference.GameState(4);
                    stop = true;
                }
            }
            
        }
    }

    public void CanActive()
    {
        canActivate = true;
    }
    public void CantActive()
    {
        canActivate = false;
    }

}
