using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float thrust = 10.0f;
    private bool goUp = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(goUp){
            rb2D.AddForce(transform.up * thrust);
        }
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Player" && !goUp){
            Debug.Log("Entered");
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(Up());
            FindObjectOfType<AudioManager>().Play("Monkey");
            // FindObjectOfType<AudioManager>().Play("Coin");
            // gameLevelManager.AddCoins(coinValue);
            // Debug.Log("Score = " + gameLevelManager.score);
            // Destroy(gameObject);
        }
    }

    IEnumerator Up(){
        yield return new WaitForSeconds(0.11f);
        goUp = true;
    }

}
