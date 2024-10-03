using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skeleton : MonoBehaviour
{
    public Vector3 position1; 
    public Vector3 position2;
    public Vector3 position3;
    public Vector3 position4;
    public int entier;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        if (entier > 4)
        {
            entier = 0;
        }
        else
        {
            entier += 1;
        }
        
        if (entier == 0)
        {    
            transform.position = position1;
        }

        else if (entier == 1)
        {
            transform.position = position2;
        }

        else if (entier == 2)
        {
            transform.position = position3; 
        }
        
        else
        {
            transform.position = position4; 
        }

    }

    
    
}
