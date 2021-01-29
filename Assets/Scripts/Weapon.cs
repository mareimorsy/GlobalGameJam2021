using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerController gamePlayer;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && gamePlayer.speed != 0f){
            Shoot();
        }
        
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
