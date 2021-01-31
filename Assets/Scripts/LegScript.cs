using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegScript : MonoBehaviour
{
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
            Debug.Log("Grass Hit back to ground legScript");
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        //     StartCoroutine(Trigger(other));
        }
    }
}
