using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject audio;
    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }

    public void PlaySound()
    {
        audio.GetComponent<AudioSource>().Play();
    }
}
