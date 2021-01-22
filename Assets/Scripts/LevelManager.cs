using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//hello this is my first comment
public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    // PlayerController Script
    public PlayerController gamePlayer;

    public int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
        scoreText.text = "Score: " + score;
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
}
