using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public Collider2D playerCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Grass"){
            Debug.Log("Grass Hit");
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            // playerCollider2D.isTrigger = true;

        //     StartCoroutine(Trigger(other));
        }
    }


    // IEnumerator Trigger(Collider2D other)
    // {
    //     other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    //     yield return new WaitForSeconds(0.2f);
    //     // other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    // }

}
