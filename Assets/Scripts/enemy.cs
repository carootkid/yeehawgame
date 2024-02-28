using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public bool alive = true;

    public float timeToDraw = 0.5f;

    public TimingManager timingManager;

    public bool alreadyShot = false;

    public Player player;

    public Animator animator;

    private bool alreadyPlayedDeathAnimation = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alive && timingManager.shouldDraw && !alreadyShot){
            StartCoroutine(Shoot());
        }

        if(!alive){
            StopCoroutine(Shoot());
            Debug.Log("enemy Dies");

            timingManager.won = true;
            

            if(!alreadyPlayedDeathAnimation)
            {
                animator.SetTrigger("Die");
                alreadyPlayedDeathAnimation = true;
                
            }
            
        }
    }
    

    public IEnumerator Shoot(){
        Debug.Log("Get ready to die");

        yield return new WaitForSeconds(timeToDraw);

        if(alive)
        {
            Debug.Log("Player FUcking DIes");

            player.alive = false;
            timingManager.lost = true;
        } else {
            Debug.Log("cant shoot already dead :(");
        }

        
    }
}
