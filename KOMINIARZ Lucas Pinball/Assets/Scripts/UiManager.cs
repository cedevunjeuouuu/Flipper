using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject hud;
    [SerializeField] KeyCode key;
    public bool stop;
    public bool canActivate;
    [SerializeField] private SetActive setActiveReference;
    [SerializeField] private GameObject blackPanel;

    
    private void Start()
    {
        GameState(3);
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (canActivate)
            {
                if (stop == true)
                {
                    GameState(3);
                    stop = false;
                }
                else
                {
                    GameState(4);
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
    
    public void GameState(int changeState)
        {
            switch (changeState)
            {
                case 2 :
                    Time.timeScale = 0;
                    options.SetActive(true);
                    pause.SetActive(false);
                    gameOver.SetActive(false);
                    takeDamage.SetActive(false);
                    hud.SetActive(false);
                    break;
                case 3 :
                    canActivate = true;
                    stop = false;
                    Time.timeScale = 1;
                    hud.SetActive(true);
                    options.SetActive(false);
                    pause.SetActive(false);
                    gameOver.SetActive(false);
                    takeDamage.SetActive(false);
                    break;
                case 4 :
                    Time.timeScale = 0;
                    pause.SetActive(true);
                    hud.SetActive(false);
                    options.SetActive(false);
                    gameOver.SetActive(false);
                    takeDamage.SetActive(false);
                    break;
                case 5 :
                    Time.timeScale = 0;
                    gameOver.SetActive(true);
                    takeDamage.SetActive(false);
                    pause.SetActive(false);
                    hud.SetActive(false);
                    options.SetActive(false);
                    break;
                    
            }
        }

    public void LoadMenu()
    {
        GameState(3);
        blackPanel.GetComponent<Animation>().Play();
    }
}
