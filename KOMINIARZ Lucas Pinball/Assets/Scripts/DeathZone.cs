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
    public int vies;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Vector3 originPosition;
    public GameObject gameOver;
    public bool dontShoot;
    public GameObject ball;
    public StopBall stop;
    public GameObject takeDamage;

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
            other.transform.position = originPosition;
        }
        else
        {
            stop.canActivate = false;
            dontShoot = true;
            gameOver.SetActive(true);
            other.transform.position = originPosition;
            
        }
        
        StartCoroutine(ShowDamageEffect());
        
        
        IEnumerator ShowDamageEffect()
        {
            takeDamage.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            takeDamage.SetActive(false);
        }


    }
}
