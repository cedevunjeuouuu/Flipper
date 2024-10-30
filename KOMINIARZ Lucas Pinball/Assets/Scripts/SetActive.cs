using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] private GameObject lightsZone2;
    [SerializeField] private GameObject blackPlane;
    void Start()
    {
        blackPlane.GetComponent<Animation>().Play();
        lightsZone2.SetActive(false);
    }
}
