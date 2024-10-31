using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] private new GameObject audio;
    public void PlaySound()
    {
        audio.GetComponent<AudioSource>().Play();
    }
    public void StopSound()
    {
        audio.SetActive(false);
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
