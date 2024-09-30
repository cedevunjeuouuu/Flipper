using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
    public float     decal;
    public float     accel;
    public float     loadingSpeed = 1;
    public KeyCode   key          = KeyCode.Space;
    public Rigidbody rb;
    public float soundDelay;
    public bool canshoot = false;
    public DeathZone deathZone;
    
    public void Shoot()
    {
        canshoot = true;
    }

    public void DontShoot()
    {
        canshoot = false;
    }
    

    void Update()
    {
        if (deathZone.dontShoot)
        {
            DontShoot();
        }
        if (Input.GetKeyUp(key))
        {
            if (canshoot == true)
            {
                rb.isKinematic = false;
                GetComponent<AudioSource>().PlayDelayed(soundDelay); 
            }
            
        }

        if (Input.GetKey(key))
        {
            if (canshoot == true)
            {
                rb.isKinematic = false;

                if (transform.localPosition.y > decal)
                {
                    rb.velocity += -transform.up * loadingSpeed;
                }
                else
                {
                    rb.velocity = Vector3.zero;
                    rb.isKinematic = true;
                } 
            }
            
        }
        else
        {
            if (transform.localPosition.y < 0)
            {
                rb.velocity += transform.up * accel;
            }
            else
            {
                rb.isKinematic = true;
                transform.localPosition = Vector3.zero;
            }
        }

        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);

    }
}