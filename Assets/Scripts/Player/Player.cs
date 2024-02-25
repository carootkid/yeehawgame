using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool alive = true;
    public bool canShoot = true;

    public TimingManager timingManager;

    public bool shot = false;

    public enemy enemyScript;

    public AudioSource audioSource;
    
    public AudioClip unholsterSound;
    public AudioClip shootSound;
    
    void Update()
    {   if (Input.GetMouseButtonDown(1) && alive)
        {
            if(timingManager.shouldDraw = true)
            {
                Debug.Log("UnHolstering.");
            } else {
                alive = false;
                Debug.Log("drew too early.");
            }
        }

        if (alive && canShoot && Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            Debug.Log("Shot");
            canShoot = false;
            shot = true;
        }

        if(timingManager.shouldDraw == true)
        {
            if(shot)
            {
                enemyScript.alive = false;
            }
        } 

        if(shot){
            shot = false;
        }

        if(!alive)
        {
            Debug.Log("player is alive'nt");
        }
    }
}
