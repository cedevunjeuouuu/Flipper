using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animation>().Play();
    }
}
