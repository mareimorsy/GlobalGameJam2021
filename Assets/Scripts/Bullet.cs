using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        // Enemy enemy = other.GetComponent<Enemy>();
        // if (enemy != null){

            if(other.tag == "EatingPlant"){
            Destroy(Instantiate(impactEffect, transform.position, transform.rotation), 0.9f);
    //         m_Animator.SetTrigger("attack");
                other.gameObject.GetComponent<Animator>().SetTrigger("hit");
            }
            // enemy.TakeDamage(enemy.damage);


        // }
        // Create Impact Effect

        Destroy(gameObject, 1f);
    }
    
}
