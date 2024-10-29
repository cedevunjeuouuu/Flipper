using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject lights1;
    [SerializeField] private GameObject lights2;
    [SerializeField] private new GameObject camera;
    [SerializeField] private Vector3 posCam;
    [SerializeField] private Vector3 newPosition1;
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = newPosition1;
        lights1.SetActive(false); 
        lights2.SetActive(true); 
        camera.transform.position = posCam;
    }
}
