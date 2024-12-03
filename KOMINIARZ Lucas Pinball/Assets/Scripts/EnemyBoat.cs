using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    [SerializeField] private int boatLife;

    private void OnTriggerEnter(Collider other)
    {
        boatLife--;
        if (boatLife <= 0)
        {
            GetComponent<Animation>().Play("Boat Enemy Sink");
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Idle()
    {
        GetComponent<Animation>().Play("Boat Enemy Idle");
    }
}
