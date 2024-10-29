using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bumper : MonoBehaviour
{
    [SerializeField] private Score scoreReference;
    [SerializeField] private new bool animation ;
    [SerializeField] private float strength = 1;
    [SerializeField] private Animation anim;
    public int points;

    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force);
        scoreReference.UpdateScore(points);
        GetComponent<AudioSource>().Play();
        if (animation)
        {
            anim.Play();
        }
    }
}
