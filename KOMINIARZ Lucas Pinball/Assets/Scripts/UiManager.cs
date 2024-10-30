using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject hud;
    
    private void Start()
    {
        GameState(3);
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
}
