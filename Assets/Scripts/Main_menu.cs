﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Skipnarrative()
    {
        SceneManager.LoadScene(4);
    }
    
    public void QuitGame()
    {
     Debug.Log("Quit!");
     Application.Quit();
    }
    public void quitTomainmenu()
    {
      SceneManager.LoadScene(0);
    }
    public void ok()
    {
        SceneManager.LoadScene(7);
    }
    public void playagain()
    {
        SceneManager.LoadScene(4);
    }
    public void Exit()
    {
    SceneManager.LoadScene(0);
    }
}
