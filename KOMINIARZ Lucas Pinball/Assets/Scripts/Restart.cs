using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private Vector3 originCamPosition;
    [SerializeField] private Score scoreReference;
    [SerializeField] private new GameObject camera;
    [SerializeField] private UiManager uiManagerReference;
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject lights1StZone;
    [SerializeField] private GameObject lights2NdZone;
    [SerializeField] private DeathZone deathZoneReference;
    // variables propres au niveau 2
    [SerializeField] private bool isLevel2;
    private Vector3 originPositionCopy;
    [SerializeField] private Vector3 heart1OriginPosition;
    [SerializeField] private Vector3 heart2OriginPosition;
    [SerializeField] private Vector3 heart3OriginPosition;
    [SerializeField] private Vector3 deathZoneOriginPosition;
    [SerializeField] private CannonScriptLv2 cannonReference;
    [SerializeField] private int boatLife;
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
        originPositionCopy = originPosition;
    }
    public void RestartButton()
    {
        if (isLevel2)
        {
            originPosition = originPositionCopy;
            heart1.transform.position = heart1OriginPosition;
            heart2.transform.position = heart2OriginPosition;
            heart3.transform.position = heart3OriginPosition;
            deathZoneReference.originPosition = originPositionCopy;
            deathZoneReference.firstZone = true;
            cannonReference.ChangeLife(boatLife);
            deathZoneReference.transform.position = deathZoneOriginPosition;
        }
        deathZoneReference.vies = 3;
        lights1StZone.SetActive(true);
        lights2NdZone.SetActive(false);
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        skeleton.skeletonPosition = 0;
        skeleton.Restart();
        StartCoroutine(ResetBall());
        scoreReference.UpdateScore(-scoreReference.score);
        scoreReference.score = 0;
        camera.transform.position = originCamPosition;
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
