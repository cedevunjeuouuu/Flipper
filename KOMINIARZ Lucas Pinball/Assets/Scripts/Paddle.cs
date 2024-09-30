using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // déclaration des variables
    public float targetPosition = 75f;
    public float originPosition = 0f;

    public new HingeJoint hingeJoint;
    private JointSpring jointSpring;

    public KeyCode key;

    private void Start()                                     //s'execute au lancement
    {
        jointSpring = hingeJoint.spring;                    
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            GetComponent<AudioSource>().Play();
        }
        
        if (Input.GetKey(key))                    //regarde si la touche est pressée 
        {
            jointSpring.targetPosition = targetPosition;    //active le paddle 
        }
        else
        {
            jointSpring.targetPosition = originPosition;    //desactive le paddle
        }
        if (Input.GetKeyUp(key))
        {
            GetComponent<AudioSource>().Play();
        }

        hingeJoint.spring = jointSpring;

    }
}
