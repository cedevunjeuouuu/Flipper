using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZoneLv2 : MonoBehaviour
{
    private int vies = 3;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private Vector3 heart1OriginPosition;
    [SerializeField] private Vector3 heart2OriginPosition;
    [SerializeField] private Vector3 heart3OriginPosition;
    public Vector3 originPosition;
    [SerializeField] private Vector3 originPositionCopy;
    [SerializeField] private Vector3 originCamPosition;
    [SerializeField] private GameObject gameOver;
    public UiManager stop;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private Score scoreReference;
    [SerializeField] private GameObject hudScore;
    [SerializeField] private new GameObject camera;
    [SerializeField] private UiManager uiManagerReference;
    [SerializeField] private Vector3 deathZonePosition;
    [SerializeField] private Skeleton skeleton;
    [SerializeField] private GameObject ball;
    public bool firstZone = true;
    [SerializeField] private GameObject lights1StZone;
    [SerializeField] private GameObject lights2NdZone;
    [SerializeField] private Vector3 deathZoneOriginPosition;
    [SerializeField] private CannonScriptLv2 cannonReference;
    [SerializeField] private int boatLife;
    
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }
    public void Restart()
    {
        originPosition = originPositionCopy;
        lights1StZone.SetActive(true);
        lights2NdZone.SetActive(false);
        vies = 3;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart1.transform.position = heart1OriginPosition;
        heart2.transform.position = heart2OriginPosition;
        heart3.transform.position = heart3OriginPosition;
        skeleton.skeletonPosition = 0;
        skeleton.Restart();
        ball.transform.SetPositionAndRotation(originPosition,quaternion.identity);
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        scoreReference.UpdateScore(- scoreReference.score);
        scoreReference.score = 0;
        camera.transform.position = originCamPosition;
        uiManagerReference.GameState(3);
        transform.position = deathZoneOriginPosition;
        firstZone = true;
        cannonReference.ChangeLife(boatLife);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        
        vies -= 1;
        if (vies == 2)
        {
            heart1.SetActive(false);
        } 
        else if (vies == 1)
        {
            heart2.SetActive(false);
        } 
        else
        {
            heart3.SetActive(false);
        } 
        
        if (vies <= 0)
        {
            stop.CantActive();
            uiManagerReference.GameState(5);
        }
        other.transform.SetPositionAndRotation(originPosition,quaternion.identity);
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.GetComponent<Rigidbody>().isKinematic = false;
        if (vies > 0)
        {
            if (firstZone)
            {
                camera.GetComponent<Animation>().Play("CameraShake");
            }
            else
            {
                camera.GetComponent<Animation>().Play("CameraShake2ndZone");
            }
            StartCoroutine(ShowDamageEffect());
        }
        
        IEnumerator ShowDamageEffect()
        {
            takeDamage.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            takeDamage.SetActive(false);
        }


    }
}
