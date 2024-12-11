using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour
{
    [SerializeField] private int boatLife;
    [SerializeField] private bool isRight;
    private GameObject spawner;
    public void Awake()
    {
        if (isRight)
        {
            spawner = GameObject.FindWithTag("Spawner Right");
        }
        else
        {
            spawner = GameObject.FindWithTag("Spawner Left");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        boatLife--;
        if (boatLife <= 0)
        {
            Destroy(this.GetComponent<BoxCollider>());
            if (isRight) 
            { 
                GetComponent<Animation>().Play("Boat Enemy Sink"); 
            }
            else
            {
                GetComponent<Animation>().Play("Boat Left Enemy Sink");
            }
            spawner.GetComponent<BoatSpawn>().Spawn();
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Idle()
    {
        if (isRight)
        {
            GetComponent<Animation>().Play("Boat Enemy Idle");
        }
        else 
        {
            GetComponent<Animation>().Play("Boat Left Enemy Idle");
        }
    }
}
