using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLv3 : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private GameObject light1StZone;
    [SerializeField] private GameObject lights2NdZone;
    [SerializeField] private BoatTrigger boatTriggerReference;
    [SerializeField] private BoatSpawn spawnRight;
    [SerializeField] private BoatSpawn spawnLeft;
    [SerializeField] private int timeSpawnRight;
    [SerializeField] private int timeSpawnLeft;
    [SerializeField] private GameObject cam;
    [SerializeField] private Vector3 originCamPosition;
    [SerializeField] private Quaternion originCamRotation;
    public void Restart()
    {
        StartCoroutine(ResetBall());
        light1StZone.SetActive(true);  
        lights2NdZone.SetActive(false);
        boatTriggerReference.waterInBoat = 1;
        boatTriggerReference.RemoveWater();
        cam.transform.SetPositionAndRotation(originCamPosition, originCamRotation);
        spawnRight.timeToWait = timeSpawnRight;
        spawnLeft.timeToWait = timeSpawnLeft;
        EnemyBoat[] enemyBoats = FindObjectsOfType<EnemyBoat>();
        foreach (EnemyBoat boat in enemyBoats)
        {
            Destroy(boat.gameObject);
        }
        
    }
    private IEnumerator ResetBall()
    {
        ball.transform.SetPositionAndRotation(originPosition, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        yield return null;
        rb.isKinematic = false;
    }
}
