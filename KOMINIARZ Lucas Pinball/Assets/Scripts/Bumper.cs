using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public new bool animation ;
    public float strength = 1;
    public Animation anim;
    
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force = (collision.transform.position - transform.position).normalized * strength;
        collision.rigidbody.AddForce(force);
        GetComponent<AudioSource>().Play();
        if (animation)
        {
            anim.Play("Bumper Bump");
        }
    }
}
