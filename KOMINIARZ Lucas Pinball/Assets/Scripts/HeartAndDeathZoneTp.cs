using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAndDeathZoneTp : MonoBehaviour
{
    [SerializeField] private bool canTp;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject deathZone;
    [SerializeField] private Vector3 newPositionHeart1;
    [SerializeField] private Vector3 newPositionHeart2;
    [SerializeField] private Vector3 newPositionHeart3;
    [SerializeField] private Vector3 newPositionDeathZone;

    private void OnTriggerEnter(Collider other)
    {
        if (canTp)
        {
            heart1.transform.position = newPositionHeart1;
            heart2.transform.position = newPositionHeart2;
            heart3.transform.position = newPositionHeart3;
            deathZone.transform.position = newPositionDeathZone;
        }
    }
}