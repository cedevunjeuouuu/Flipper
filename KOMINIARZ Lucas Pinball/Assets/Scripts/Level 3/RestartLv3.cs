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
    [SerializeField] private UiManager uiManagerReference;
    [SerializeField] private float waterOriginalZAxis;
    [SerializeField] private Score scoreReference;
    public void Restart()
    {
        StartCoroutine(ResetBall());
        light1StZone.SetActive(true);  
        lights2NdZone.SetActive(false);
        scoreReference.score = 0;
        scoreReference.UpdateScore(0);
        boatTriggerReference.waterInBoat = 0;
        boatTriggerReference.sliderWater.value = 0f;
        boatTriggerReference.waterPlane.transform.position = boatTriggerReference.waterOriginPosition;
        boatTriggerReference.waterPlaneZAxis = waterOriginalZAxis;
        boatTriggerReference.RemoveWater();
        cam.transform.SetPositionAndRotation(originCamPosition, originCamRotation);
        spawnRight.timeToWait = timeSpawnRight;
        spawnLeft.timeToWait = timeSpawnLeft;
        EnemyBoat[] enemyBoats = FindObjectsOfType<EnemyBoat>();
        foreach (EnemyBoat boat in enemyBoats)
        {
            Destroy(boat.gameObject);
        }
        uiManagerReference.GameState(3);
        
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
