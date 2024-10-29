using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject lightsZone2;
    void Start()
    {
        lightsZone2.SetActive(false);
        canvas.SetActive(true);
    }
    
}
