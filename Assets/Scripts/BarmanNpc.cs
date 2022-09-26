using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Assets.SimpleLocalization;

//version 1.0
public class BarmanNpc : MonoBehaviour, IInteractable
{
    [Header("Inspector Set up")]

    public Animator animator;
    public AudioSource waveAudio, interactAudio; //basic Audios
    [TextArea(3,10)]
    public string[] dialogues; //array of string of NPC dialogues
    public UnityEvent onEndDialogue; //unity event can be really useful on Inspector

    [Header("Interaction related")]

    Interactor interactor; //saved interactor, assign on interact
    int dialogueIndex; //index of string we are currently on dialogues
    bool onInteract; //flag when we are on interact
    public string hintText;

    

    void Start(){
        //reset
        onInteract = false;
        interactor = null;
        dialogueIndex = 0;

        LocalizationManager.Language = GameManager.lang;
    }

    public string GetTxt(){
        if(hintText!=null){
            string temp = LocalizationManager.Localize(hintText);
            return temp;
        }
        return "error";
    }

    //called from HumanNPCSight when player enters an area near NPC
    public void SawPlayer(){
        animator.SetTrigger("Waving");
        if (waveAudio!=null) waveAudio.Play();
    }


    //IInteractable implementation
    public void OnInteract(Interactor newInteractor)
    {
        onInteract = true; //flag to true
        interactor = newInteractor; //store interactor for later
        dialogueIndex = 0; //reset

        animator.SetBool("talking", true);
        animator.SetBool("bartending", false);

        if (interactAudio!=null) interactAudio.Play(); //play audio if exists

        GiveNextDialogue(); //give next dialogue, basically first dialogue
    }

    //send interactor next string to diplay
    void GiveNextDialogue(){
        //if dialogue index have reaches max dialogues
        //index + 1 (for next dialogue) greater than the amount of dialogue strings
        if (dialogueIndex+1 > dialogues.Length){
            OnEndDialogue();
            return;
        }

        string tempDial = LocalizationManager.Localize(dialogues[dialogueIndex]);

        interactor.ReceiveInteract(tempDial);
        dialogueIndex++; //ready for next dialogue
    }

    //request interactor to end interact, Call event and reset variables
    void OnEndDialogue(){
        interactor.EndInteract(gameObject); //request interactor to end Interact

        onEndDialogue.Invoke(); //call event

        OnEndInteract(); //call self EndInteract method
        
    }

    //reset variables
    public void OnEndInteract()
    {
        onInteract = false;
        interactor = null;
        dialogueIndex = 0;
        interactAudio.Stop();
  }

    // Update is called once per frame
    void Update(){
        //button default name for Enter etc
        if (onInteract && Keyboard.current.enterKey.wasPressedThisFrame && interactor!=null){
            GiveNextDialogue();
        }
    }


}
