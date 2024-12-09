using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public int vies = 3;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private GameObject gameOver;
    public UiManager stop;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private new GameObject camera;
    [SerializeField] private UiManager uiManagerReference;
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
            camera.GetComponent<Animation>().Play("CameraShake");
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
