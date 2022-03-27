using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int outScene, inScene, tavernScene, prevScene1;
    public static GameManager manager;
    

    public enum Scene {
        tavern, 
        village,
    }


    void Awake(){
        if (manager == null){
            manager = this;
            DontDestroyOnLoad(this);
        }else if (manager != this){
            //Destroy(gameObject);
        }

        
    }



    // Start is called before the first frame update
    void Start()
    {
        outScene = 1;
        inScene = 2;
        tavernScene = 3;
       // prevScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goOut(){
        if (1 != SceneManager.GetActiveScene().buildIndex){
            prevScene1 = 1;
            SceneManager.LoadScene(outScene);
        }   
    }

     public void goIn(){
        //prevScene = SceneManager.GetActiveScene().buildIndex;
        prevScene1 = 1;
        if (2 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(inScene);
        }   
    }

     public void goTavern(){
        prevScene1 = 0;
        Debug.Log(prevScene1.ToString());
        if (3 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(tavernScene);
        }   
    }

    public int getPrevScene(){
        return prevScene1;
    }

    public void setPrev(int i){
        prevScene1 = i;
    }

     public void QuitGame(){
        Application.Quit();

        Debug.Log("quit");
    }
}
