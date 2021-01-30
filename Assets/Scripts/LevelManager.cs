using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//hello this is my first comment
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    // PlayerController Script
    public PlayerController gamePlayer;
    public Health playerHealth;

    public int score = 0;
    public int health = 3;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
        playerHealth = FindObjectOfType<Health> ();
        scoreText.text = "Score: " + score;
        Debug.Log(playerHealth.health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn(){
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine(){
        // gemeObject refers to the object which the script is attached to which is the player
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds (respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint; 
        gamePlayer.gameObject.SetActive(true);
    }

    public void AddCoins( int numOfCoins){
        score += numOfCoins;
        scoreText.text = "Score: " + score;
    }
    
    
    public void GameOver()
    {
     SceneManager.LoadScene(5);
    }


    public void Damage(){
        health -= 1;
        playerHealth.health = health;
        Debug.Log(playerHealth.health);
        if(health == 0){
            GameOver();
        }
    }
}
