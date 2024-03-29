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

    public Animator animator;

    private bool alreadyDead;

    private bool canHolster = true;
    
    void Update()
    {   if (Input.GetMouseButtonDown(1) && alive && timingManager.gameStarted && canHolster)
        {
            if(timingManager.shouldDraw == true)
            {
                Debug.Log("UnHolstering.");
                animator.SetTrigger("UnHolster");
                audioSource.PlayOneShot(unholsterSound);
            } else {
                alive = false;
                Debug.Log("drew too early.");
            }
        }

        if (timingManager.gameStarted && alive && canShoot && Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && canHolster)
        {
            Debug.Log("Shot");
            audioSource.PlayOneShot(shootSound);
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
            animator.SetTrigger("shoot");
            StartCoroutine(WinAnimation());
        }

        if(!alive && !alreadyDead && canHolster)
        {
            Debug.Log("player is alive'nt");
            animator.SetTrigger("diesnormaly");
            alreadyDead = true;
        }
    }

    public IEnumerator WinAnimation()
    {
        yield return new WaitForSeconds(1);

        animator.SetTrigger("win");

        canHolster = false;
    }
}
