using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private bool isLevel3 = true;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animation>().Play();
        if (isLevel3)
        {
            cam.GetComponent<Animation>().Play("CameraShakeShootLv3");
        }
        else
        {
            cam.GetComponent<Animation>().Play("CameraShakeShootLv2");
        }
        GetComponent<AudioSource>().Play();
    }
}
