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
    [SerializeField] private GameObject hudScore;
    [SerializeField] private new GameObject camera;
    [SerializeField] private UiManager uiManagerReference;
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject lights1StZone;
    [SerializeField] private GameObject lights2NdZone;
    [SerializeField] private DeathZone deathZoneReference;
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }
    public void RestartButton()
    {
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
