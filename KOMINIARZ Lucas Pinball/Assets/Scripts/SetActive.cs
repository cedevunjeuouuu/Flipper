using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    void Start()
    {
        canvas.SetActive(true);
    }
    
}
