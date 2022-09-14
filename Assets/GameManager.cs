using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SimpleLocalization;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public static string lang = "English";

    void Awake(){
        if (manager == null){
            manager = this;
            DontDestroyOnLoad(this);
        }else if (manager != this){
            //Destroy(gameObject);
        } 

        LocalizationManager.Read();

/*
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Greek:
                LocalizationManager.Language = "Greek";
                break;
            default:
                LocalizationManager.Language = "English";
                break;
        }
        */

        LocalizationManager.Language = "English";
    }


    public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
            Debug.Log(localization);
            lang = localization;
		}





    public void start(){
        //canvas.SetActive(false);
        if (2 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(2);
        }   
    }

    public void goIn(){
        if (2 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(2);
        }   
    }

    public void goTavern(){
        if (3 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(3);
        }   
    }


    public void QuitGame(){
        Application.Quit();

        Debug.Log("quit");
    }
}
