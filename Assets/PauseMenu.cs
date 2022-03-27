using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static PauseMenu menu;
    [SerializeField] private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)){
            if (isPaused){
                ResumeGame();
                 //Debug.Log("resume");
            }else{
                PauseGame();
                 //Debug.Log("pause");
            }
        }
    }

     void Awake(){
        if (menu == null){
            menu = this;
            DontDestroyOnLoad(this);
        }else if (menu != this){
            //Destroy(gameObject);
        }
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame(){
        Application.Quit();

        Debug.Log("quit");
    }
}
