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
        LocalizationManager.Language = "English";
    }


    public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
            Debug.Log(localization);
            lang = localization;
		}



    public void goIn(){
        if (1 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(1);
        }   
    }

    public void goTavern(){
        if (2 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(2);
        }   
    }


    public void QuitGame(){
        Application.Quit();

        Debug.Log("quit");
    }
}
