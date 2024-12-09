using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneLv3 : MonoBehaviour
{
    [SerializeField] private BoatTrigger boatTriggerReference;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private Vector3 originCamPosition;
    [SerializeField] private Quaternion originCamRotation;
    [SerializeField] private GameObject cam;
    private void OnTriggerEnter(Collider other)
    {
        boatTriggerReference.AddWater();
        other.transform.position = originPosition;
        cam.transform.SetPositionAndRotation(originCamPosition,originCamRotation);
        cam.GetComponent<Animation>().Play("CameraShake");
    }
}
