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
    [SerializeField] private GameObject lights1StZone;
    [SerializeField] private GameObject lights2NdZone;
    private void OnTriggerEnter(Collider other)
    {
        boatTriggerReference.AddWater();
        other.transform.position = originPosition;
        cam.transform.SetPositionAndRotation(originCamPosition,originCamRotation);
        lights1StZone.SetActive(true);
        lights2NdZone.SetActive(false);
        cam.GetComponent<Animation>().Play();
        this.GetComponent<AudioSource>().Play();

    }
}
