using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public LevelManager gameLevelManager;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Bullet"){
            // m_Animator.SetTrigger("attack");
            isDead = true;
        }

        if(other.tag == "Player"){
            // m_Animator.SetTrigger("attack");
            if(!isDead){
            gameLevelManager.Damage();
            other.gameObject.GetComponent<PlayerController>().Flicker();
            }
        }
    }


        // if(other.tag == "EatingPlant"){
        //     if(other.gameObject.GetComponent<Plant> ().isDead == false){
        //         gameLevelManager.Damage();
        //         StartCoroutine(Flash());
        //     }
        // }
}
