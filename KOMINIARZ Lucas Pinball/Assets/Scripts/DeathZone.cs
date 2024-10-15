using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private int vies = 3;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private GameObject gameOver;
    public bool dontShoot;
    [SerializeField] private GameObject ball;
    public StopBall stop;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private Score scoreReference;
    [SerializeField] private GameObject hudScore;
        
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }
    public void Restart()
    {
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        vies = 3;
        dontShoot = false;
        gameOver.SetActive(false);
        ball.transform.position = originPosition;
        stop.canActivate = true;
        scoreReference.UpdateScore(scoreReference.score = 0);
        hudScore.SetActive(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        vies -= 1;
        if (vies == 2)
        {
            heart1.SetActive(false);
        } 
        else if (vies == 1)
        {
            heart2.SetActive(false);
        } 
        else
        {
            heart3.SetActive(false);
        } 
        
        if (vies > 0)
        {
            dontShoot = false;
        }
        else
        {
            stop.canActivate = false;
            dontShoot = true;
            gameOver.SetActive(true);
            hudScore.SetActive(false);
        }
        ball.GetComponent<Rigidbody>().isKinematic = true;
        other.transform.position = originPosition;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        
        StartCoroutine(ShowDamageEffect());
        
        
        IEnumerator ShowDamageEffect()
        {
            takeDamage.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            takeDamage.SetActive(false);
        }


    }
}
