using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Vector3 position1; 
    [SerializeField] private Vector3 position2;
    [SerializeField] private Vector3 position3;
    [SerializeField] private Vector3 position4;
    public int skeletonPosition;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        if (skeletonPosition > 2)
        {
            skeletonPosition = 0;
        }
        else
        {
            skeletonPosition += 1;
        }
        
        if (skeletonPosition == 0)
        {    
            transform.position = position1;
        }

        else if (skeletonPosition == 1)
        {
            transform.position = position2;
        }

        else if (skeletonPosition == 2)
        {
            transform.position = position3; 
        }
        
        else
        {
            transform.position = position4; 
        }

    }

    public void Restart()
    {
        transform.position = position1;
    }
    
}
