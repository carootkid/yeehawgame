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

    public Animator playerAnimator;

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
        }
    }
    

    public IEnumerator Shoot(){
        Debug.Log("Get ready to die");

        yield return new WaitForSeconds(timeToDraw);

        if(alive)
        {
            Debug.Log("Player FUcking DIes");

            player.alive = false;
        } else {
            Debug.Log("cant shoot already dead :(");
        }

        
    }
}
