using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWaterBuckets : MonoBehaviour
{
    [SerializeField] private BoatTrigger boatTriggerReference;

    private void OnTriggerEnter(Collider other)
    {
        boatTriggerReference.RemoveWater();
    }
}
