using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class ChromaticAberrationTrigger : MonoBehaviour
{
    public Volume globalVolume; // Référence au Global Volume
    private ChromaticAberration chromaticAberration;
    private bool playerInTrigger = false;
    [SerializeField] private Bumper bumper1;
    [SerializeField] private Bumper bumper2;
    [SerializeField] private AddPointsTrigger trigger1;
    [SerializeField] private AddPointsTrigger trigger2;
    [SerializeField] private GameObject namePowerUp;
    [SerializeField] private Score canActivePower;
    

    void Start()
    {
        if (globalVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration))
        {
            canActivePower.CanActivePowerUp(true);
            chromaticAberration.intensity.value = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInTrigger && canActivePower.canActive)
        {
            canActivePower.CanActivePowerUp(false);
            namePowerUp.SetActive(true);
            namePowerUp.GetComponent<Animation>().Play();
            bumper1.points *= 2;
            bumper2.points *= 2;
            trigger1.points *= 2;
            trigger2.points *= 2;
            playerInTrigger = true;
            GetComponent<AudioSource>().Play();
            StartCoroutine(Aberration());
        }
    }
    IEnumerator Aberration()
    {
        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            chromaticAberration.intensity.value = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }
        
        yield return new WaitForSeconds(5f);
        time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            chromaticAberration.intensity.value = Mathf.Lerp(1f, 0f, t);
            yield return null;
        }
        bumper1.points /= 2;
        bumper2.points /= 2;
        trigger1.points /= 2;
        trigger2.points /= 2;
        namePowerUp.SetActive(false);
        canActivePower.CanActivePowerUp(true);
        playerInTrigger = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
