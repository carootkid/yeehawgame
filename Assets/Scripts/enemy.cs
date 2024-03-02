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

    public bool AttackAnimation = true;

    public AudioSource enemySource;


    public AudioClip[] countdownClips;
    public AudioClip[] deathClips;

    private bool alreadySpoke = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timingManager.start && alive && !alreadySpoke){
            
            int randomInt = Random.Range(0, countdownClips.Length);
            Debug.Log(randomInt);
            AudioClip speakClip = countdownClips[randomInt];

            enemySource.PlayOneShot(speakClip);

            alreadySpoke = true;
        }

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

                
                enemySource.Stop();

                int randomInt = Random.Range(0, deathClips.Length);
                Debug.Log(randomInt);
                AudioClip deathClip = deathClips[randomInt];

                enemySource.PlayOneShot(deathClip);
                
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

            if(AttackAnimation)
            animator.SetTrigger("ShootPlayer");
            
        } else {
            Debug.Log("cant shoot already dead :(");
        }

        
    }
}
