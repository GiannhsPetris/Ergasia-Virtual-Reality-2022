using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;

    public void QuitGame(){
        Application.Quit();

        Debug.Log("quit");
    }

     public void goIn(){
        canvas.SetActive(false);
        //prevScene = SceneManager.GetActiveScene().buildIndex;

        if (2 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(2);
        }   
    }
}
