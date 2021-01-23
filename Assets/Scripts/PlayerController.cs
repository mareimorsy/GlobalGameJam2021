using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;
    private bool isRightDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");

        if(movement > 0f){
            rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
            flip();
        }else if(movement < 0f){
            rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
            flip();
        }else{
            rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isTouchingGround){
            FindObjectOfType<AudioManager>().Play("Jump");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "FallDetector"){
            gameLevelManager.Respawn();
        }

        if(other.tag == "Checkpoint"){
            respawnPoint = other.transform.position;
        }
    }

    void flip(){
        if (movement > 0f && !isRightDirection){
            isRightDirection = true;
            transform.Rotate(0f, 180f, 0f);
        }
        
        if (movement < 0f && isRightDirection ){
            isRightDirection = false;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
