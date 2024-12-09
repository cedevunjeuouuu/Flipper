using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    public void LoadLevel1()
    {
        cam.GetComponent<Animation>().Play("Anim Go To Level");
    }
    public void LoadLevel2()
    {
        cam.GetComponent<Animation>().Play("Anim Go To Level 2");
    }
    public void LoadLevel3()
    {
        cam.GetComponent<Animation>().Play("Anim Go To Level 3");
    }
    public void LoadCredits()
    {
        cam.GetComponent<Animation>().Play("Anim Go To Credits");
    }
    
    public void ButtonBack()
    {
        cam.GetComponent<Animation>().Play("Anim 1 camera menu");
    }
    public void ButtonPlay()
    {
        cam.GetComponent<Animation>().Play("anim 2 camera menu");
    }
    public void ButtonQuit()
    {
        Application.Quit();
    }
}