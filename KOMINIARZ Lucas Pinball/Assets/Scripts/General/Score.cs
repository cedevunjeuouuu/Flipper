using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject scoreGameOver;
    public bool canActive = true;
    public int score = 0;
    
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.GetComponent<TMP_Text>().text = "Score : " + score;
        scoreGameOver.GetComponent<TMP_Text>().text = "Score : " + score;
    }

    public void CanActivePowerUp(bool par)
    {
        canActive = par;
    }
}
