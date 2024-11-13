using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsTrigger : MonoBehaviour
{
    [SerializeField] private Score scoreReference;
    public int points;
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        scoreReference.UpdateScore(points);
    }
}
