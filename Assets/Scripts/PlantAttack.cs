using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        // m_Animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            m_Animator.SetTrigger("attack");
        }
    }
    
}
