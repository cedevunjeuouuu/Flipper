using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatTrigger : MonoBehaviour
{
    public int waterInBoat = 0;
    private int holdCapacity = 5;
    [SerializeField] private UiManager uiManagerReference;
    public Slider sliderWater;
    public GameObject waterPlane;
    public float waterPlaneZAxis = 0.4f;
    public Vector3 waterOriginPosition;
    private bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        AddWater();
    }
    
    public void AddWater()
    {
        waterInBoat++;
        waterPlaneZAxis -= 0.4f;
        Vector3 newPosition = new Vector3(0, 0, Mathf.Clamp(waterPlaneZAxis - 0.4f, waterPlaneZAxis, waterPlaneZAxis - 0.4f));
        StartCoroutine(MoveWaterPlane(waterPlane.transform, newPosition, 1f));
        sliderWater.value = waterInBoat;
        if (waterInBoat >= holdCapacity)
        {
            uiManagerReference.GameState(5);
        }
    }
    public void RemoveWater()
    {
        if (waterInBoat > 0 && !isMoving)
        {
            waterInBoat--; 
            waterPlaneZAxis += 0.4f;
            Vector3 newPosition = waterPlane.transform.position + new Vector3(0, 0, +0.4f);
            StartCoroutine(MoveWaterPlane(waterPlane.transform, newPosition, 1f));
            sliderWater.GetComponent<Slider>().value = waterInBoat;
        }
        else if (waterInBoat == 0)
        {
            waterPlane.transform.position = waterOriginPosition;
        }
    }
    private IEnumerator MoveWaterPlane(Transform obj, Vector3 targetPosition, float duration)
    {
        isMoving = true;
        Vector3 startPosition = obj.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            obj.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.position = targetPosition;
        isMoving = false;
    }
}
