using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    private bool hit = false;
    public LevelManager gameLevelManager;
    
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && !hit){
            Debug.Log("Hit and Run");
            other.gameObject.GetComponent<PlayerController>().Flicker();
            gameLevelManager.Damage();
            hit = true;
        }
    }
}
