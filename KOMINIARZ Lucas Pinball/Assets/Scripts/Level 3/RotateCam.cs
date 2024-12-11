using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField] private new GameObject camera;
    [SerializeField] private Quaternion newRotation;

    private void OnTriggerEnter(Collider other)
    {
        camera.GetComponent<Transform>().rotation = newRotation;
    }
}
