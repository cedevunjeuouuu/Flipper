using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boat;
    [SerializeField] private int timeToWait = 15;
    [SerializeField] private int timeBeforeFirstSpawn;
    private int spawnCount;
    private void Start()
    {
        StartCoroutine(FirstSpawn()); 
    }
    IEnumerator FirstSpawn()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        Instantiate(boat);
    }
    public void Spawn()
    {
        if (timeToWait - spawnCount<=2)
        {
            StartCoroutine(ContinueSpawn());

        }
        else
        {
            StartCoroutine(SpawnBoatAfterTime());
        }
    }
    IEnumerator ContinueSpawn()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(boat);
    }


    IEnumerator SpawnBoatAfterTime()
    {
        yield return new WaitForSeconds(timeToWait - spawnCount);
        spawnCount++;
        Instantiate(boat);
    }

    
}
