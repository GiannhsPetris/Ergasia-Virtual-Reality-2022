using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    public GameObject postProDrunk;
    public UnityEvent onEndAnim;
    public int aleCounter;
    public TextMeshProUGUI aleCounterUI;
    public GameObject character;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aleCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDrunk(){
        animator.speed = 0.5f;
        postProDrunk.SetActive(true);
        GetComponent<StarterAssets.ThirdPersonController>().MoveSpeed = 1f;
        GetComponent<StarterAssets.ThirdPersonController>().SprintSpeed = 0f;
    }

    public void GetUnDrunk(){
        animator.speed = 1;
        postProDrunk.SetActive(false);
        GetComponent<StarterAssets.ThirdPersonController>().MoveSpeed = 2f;
        GetComponent<StarterAssets.ThirdPersonController>().SprintSpeed = 5.335f;
        aleCounter = 0;
        aleCounterUI.text = "Ales Drunk: " + aleCounter.ToString();
    }

    public void startEvent(){
        onEndAnim.Invoke();
    }

    public void aleDrunk(){
        aleCounter+=1;
        aleCounterUI.text = "Ales Drunk: " + aleCounter.ToString();
        if (aleCounter >= 2){
            GetDrunk();
        }
    }

    
}
