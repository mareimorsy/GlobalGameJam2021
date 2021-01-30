using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Rigidbody2D banana;
    public float thrust = 10.0f;
    private bool goUp = false;
    public float bananaThrust = 500;
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
            banana.bodyType = RigidbodyType2D.Dynamic;
            banana.AddForce(Vector2.left * bananaThrust);
            // FindObjectOfType<AudioManager>().Play("Coin");
            // gameLevelManager.AddCoins(coinValue);
            // Debug.Log("Score = " + gameLevelManager.score);
            // Destroy(gameObject);
            Destroy(gameObject, 6f);
        }
    }

    IEnumerator Up(){
        yield return new WaitForSeconds(0.11f);
        goUp = true;
    }

}
