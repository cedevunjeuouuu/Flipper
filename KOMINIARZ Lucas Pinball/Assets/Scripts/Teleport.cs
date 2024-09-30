using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 newPosition;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = newPosition;
    }
}
