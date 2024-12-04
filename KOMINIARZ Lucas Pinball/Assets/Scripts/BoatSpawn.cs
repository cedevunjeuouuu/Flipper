using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boat;
    [SerializeField] private int timeToWait = 15;
    private bool canSpawn = false;
    private int spawnCount;
    private void Start()
    {
        Instantiate(boat);
    }
    void Spawn()
    {
        if (canSpawn && timeToWait - spawnCount<=0)
        {
            Instantiate(boat);
            
        }
        else if (canSpawn)
        {
            StartCoroutine(SpawnBoatAfterTime());
        }
    }

    IEnumerator SpawnBoatAfterTime()
    {
        yield return new WaitForSeconds(timeToWait - spawnCount);
        spawnCount++;
        Instantiate(boat);
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
