using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject canvas1;
    [SerializeField] private GameObject canvas2;
    [SerializeField] private GameObject door;

    private void Start()
    {
        canvas1.SetActive(true);
    }

    public void HideCanvas1()
    {
        canvas1.SetActive(false);
    }
    public void HideCanvas2()
    {
        canvas2.SetActive(false);
    }
    public void ShowCanvas1()
    {
        canvas1.SetActive(true);
    }
    public void ShowCanvas2()
    {
        canvas2.SetActive(true);
    }

    public void DoorAnimationLaunch()
    {
        door.GetComponent<Animation>().Play("Door Anim");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
}
