using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AskChangeLevel : MonoBehaviour
{
    [SerializeField] private GameObject askHud;
    
    private void OnTriggerEnter(Collider other)
    {
        ChangeTimeScale(0f);
        askHud.SetActive(true);
    }

    public void ChangeTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }
}
