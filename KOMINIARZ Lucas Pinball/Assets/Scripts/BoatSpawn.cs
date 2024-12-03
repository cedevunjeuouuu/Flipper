using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boat;
    private bool canSpawn;
    private int spawnCount;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        Instantiate(boat);
        spawnCount++;
    }
    public void CantSpawn()
    {
        canSpawn = false;
    }
    public void CanSpawn()
    {
        canSpawn = true;
    }
    
}
