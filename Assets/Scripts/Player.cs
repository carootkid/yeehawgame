using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canShoot = true;
    
    void Update()
    {   if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("UnHolstering.");
        }

        if (canShoot && Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            Debug.Log("Shot");
            canShoot = false;
        }
    }
}
