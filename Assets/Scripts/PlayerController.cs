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
    public Animator m_Animator;
    public bool autoRun = true;
    private float defaultSpeed;
    public SpriteRenderer sr;
    public SpriteRenderer pressAnyKeySprite;

    // Start is called before the first frame update
    void Start()
    {
        pressAnyKeySprite.enabled = false;
        rigidBody = GetComponent<Rigidbody2D> ();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager> ();
        m_Animator = gameObject.GetComponent<Animator>();
        defaultSpeed = speed;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && speed == 0f)
        {
            pressAnyKeySprite.enabled = false;
            StartCoroutine(pressAnyKeyToContinue());
            return;
        }

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        m_Animator.SetBool("isGrounded", isTouchingGround);
        m_Animator.SetFloat("speed", speed);
        
        movement = Input.GetAxis("Horizontal");


        if(autoRun){
            rigidBody.velocity = new Vector2 (speed, rigidBody.velocity.y);
        }else{
            if(movement > 0f){
                rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
                flip();
            }else if(movement < 0f){
                rigidBody.velocity = new Vector2 (movement * speed, rigidBody.velocity.y);
                flip();
            }else{
                rigidBody.velocity = new Vector2 (0, rigidBody.velocity.y);
            }
        }

        if(Input.GetButtonDown("Jump") && isTouchingGround){
            FindObjectOfType<AudioManager>().Play("Jump");
            // rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            rigidBody.AddForce(new Vector2(rigidBody.velocity.x, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "FallDetector"){
            speed = 0;
            pressAnyKeySprite.enabled = true;
            gameLevelManager.Respawn();
        }
        if(other.tag == "Trap"){
            StartCoroutine(Flash());
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

    IEnumerator pressAnyKeyToContinue(){
        yield return new WaitForSeconds(0.25f);
        speed = defaultSpeed;
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 2; n++)
        {
            sr.color = new Color(1f,1f,1f,.25f);// is about 50% transparent
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1f,1f,1f,1f);// is a normal sprite
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Flicker(){
        StartCoroutine(Flash());
    }
}
