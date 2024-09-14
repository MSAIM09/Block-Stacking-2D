using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour 
{
    public static UIManagerScript instance;

    public Button StartButton;
    public Button levelButton;
    public Button ExitButton;
    public Button BackButton;
   // public Button RetryButton;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void StartGame() 
    {
       SceneManager.LoadScene("Level 1");
    }

    public void OpenSettings() 
    {
        
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void Back()
    {
        SceneManager.LoadScene("MenuScene"); 
    }

   /* public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }*/

}
