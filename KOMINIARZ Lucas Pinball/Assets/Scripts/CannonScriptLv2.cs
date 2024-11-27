using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScriptLv2 : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject boat;
    [SerializeField] private int boatLife;

    private void OnTriggerEnter(Collider other)
    {
        boatLife --;
        cannon.GetComponent<Animation>().Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        if (boatLife == 0)
        {
            boat.GetComponent<Animation>().Play("Boat lv2 Sink");
        }
        else if(boatLife > 0)
        {
            boat.GetComponent<Animation>().Play();
        }
    }

    public void ChangeLife(int newLife)
    {
        boatLife = newLife;
        StartCoroutine(Wait());
    }
}
