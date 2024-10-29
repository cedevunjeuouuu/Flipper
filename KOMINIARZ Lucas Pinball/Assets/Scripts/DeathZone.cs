using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private int vies = 3;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private Vector3 originPosition;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject ball;
    public StopBall stop;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private Score scoreReference;
    [SerializeField] private GameObject hudScore;
    [SerializeField] private new GameObject camera;
    [SerializeField] private UiManager uiManagerReference;
    [SerializeField] private Vector3 deathZonePosition;
        
    private void Start()
    {
        scoreReference = FindObjectOfType<Score>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        Instantiate(ball, originPosition,Quaternion.identity);
        Destroy(other);
        if (vies > 0)
        {
            camera.GetComponent<Animation>().Play();
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
