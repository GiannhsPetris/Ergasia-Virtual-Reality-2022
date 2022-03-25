using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Author: apostolos SOVOLOS
//Version: 1.0

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] protected bool isOn, isJammed; //jammed = can't be used
    [TextArea(2,10)]
    [SerializeField] protected string jammedText = "Lever is jammed."; //output text if lever is jammed/can't be used
    [SerializeField] protected Animator animator;
    [SerializeField] protected UnityEvent onLeverOn; //unity event can be really useful on Inspector
    [SerializeField] protected UnityEvent onLeverOff; //https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html
    public string hintText;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("On", isOn); //initialize animator state
    }

    //OnInteract is by Interactor (Player), implementation from IInteractable
    public virtual void OnInteract(Interactor interactor){
        if (isJammed){
            interactor.ReceiveInteract(jammedText); //send text to output
        }
        else {
            isOn = !isOn; //boolean switch 
            animator.SetBool("On", isOn); //update animator state

            if (isOn) onLeverOn.Invoke(); //execute inspector methods On
            else onLeverOff.Invoke(); //execute inspector methods Off
        }
    }

    //Make lever unusable and update lever
    public void Jam(){
        isJammed = true;
        isOn = false;
        animator.SetBool("On", false);
    }

    //Make Lever usable
    public void UnJam(){
        isJammed = false;
    }

     public string GetTxt(){
        if(hintText!=null){
            return hintText;
        }
        return "error";
    }
}
