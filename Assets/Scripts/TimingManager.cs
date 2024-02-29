using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public GameObject waitCam;
    public GameObject gameCam;
    public AudioSource audioSource;
    public AudioClip changeClip;
    public AudioClip drawClip;

    public float intervalSpeed;
    
    public float minTime;
    public float maxTime;

    public GameObject pressE;
    public GameObject ready;
    public GameObject set;
    public GameObject draw;

    public bool gameStarted = false;

    public bool start = false;
    public bool shouldDraw = false;

    public bool won = false;
    public bool lost = false;

    private bool alreadyPlayedWinLoseAnim = false;

    private Animator gameCamAnimator;

    private void Start() {
        waitCam.SetActive(true);
        gameCam.SetActive(false);

        pressE.SetActive(true);
        ready.SetActive(false);
        set.SetActive(false);
        draw.SetActive(false);

        
        gameCamAnimator = gameCam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!start && Input.GetKeyDown(KeyCode.E)){
            waitCam.SetActive(false);
            gameCam.SetActive(true);
            start = true;
            StartCoroutine(StartCountdown());

            gameStarted = true;
        }


        if(won && !alreadyPlayedWinLoseAnim){
            StartCoroutine(StartWinAnim());
            alreadyPlayedWinLoseAnim = true;
        } else if(lost && !alreadyPlayedWinLoseAnim)
        {
            StartCoroutine(StartLoseAnim());
            alreadyPlayedWinLoseAnim = true;
        }
    }

    public IEnumerator StartCountdown()
    {
        audioSource.PlayOneShot(changeClip);

        pressE.SetActive(false);
        ready.SetActive(true);
        set.SetActive(false);
        draw.SetActive(false);

        yield return new WaitForSeconds(intervalSpeed);

        audioSource.PlayOneShot(changeClip);

        ready.SetActive(false);
        set.SetActive(true);

        float randomTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomTime);

        audioSource.PlayOneShot(drawClip);

        set.SetActive(false);
        draw.SetActive(true);

        shouldDraw = true;

        yield return new WaitForSeconds(1);
        
        draw.SetActive(false);
    }

    public IEnumerator StartWinAnim(){
        yield return new WaitForSeconds(1);

        gameCamAnimator.SetTrigger("Won");
    }

    public IEnumerator StartLoseAnim(){
        yield return new WaitForSeconds(1);

        gameCamAnimator.SetTrigger("Lost");
    }
}
