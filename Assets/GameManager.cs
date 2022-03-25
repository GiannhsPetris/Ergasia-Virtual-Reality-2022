using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int outScene, inScene, tavernScene, currentScene;
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
            Destroy(gameObject);
        }

        
    }



    // Start is called before the first frame update
    void Start()
    {
        outScene = -1;
        inScene = 1;
        tavernScene = 0;
        currentScene = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goOut(){
        if (-1 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(outScene);
            SceneManager.UnloadSceneAsync(inScene);
            SceneManager.UnloadSceneAsync(tavernScene);
            currentScene = 0;
        }   
    }

     public void goIn(){
        if (1 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(inScene);
            //SceneManager.UnloadSceneAsync(outScene);
            //SceneManager.UnloadSceneAsync(tavernScene);
            currentScene = 1;
        }   
    }

     public void goTavern(){
        if (0 != SceneManager.GetActiveScene().buildIndex){
            SceneManager.LoadScene(tavernScene);
            //SceneManager.UnloadSceneAsync(inScene);
            //SceneManager.UnloadSceneAsync(outScene);
            currentScene = 2;
        }   
    }
}
