using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//version 1.0
public class HumanNPC : MonoBehaviour, IInteractable
{
    //------Setup in Inspector---------------------
    public Animator animator;
    public AudioSource waveAudio, interactAudio; //basic Audios
    [TextArea(3,10)]
    public string[] dialogues, dialogueKey, dialogueHint, dialogueQuest; //array of string of NPC dialogues
    public UnityEvent onEndDialogue, key, quest; //unity event can be really useful on Inspector
    string currentAnim;
    public string hintText;
    //----------------------------------------------
    Interactor interactor; //saved interactor, assign on interact
    int dialogueIndex; //index of string we are currently on dialogues
    bool onInteract; //flag when we are on interact
    public bool beggarHint = false;
    public bool foundKey = false;
    public bool questGiven = false;

    void Start(){
        //reset
        onInteract = false;
        interactor = null;
        dialogueIndex = 0;
        currentAnim = GetComponent<npc_animations>().state;
       
    }

     public string GetTxt(){
        if(hintText!=null){
            return hintText;
        }
        return "error";
    }

    public void setHint(bool set){
        beggarHint = set;
    }

    public void setKey(bool set){
        foundKey = set;
    }


    //called from HumanNPCSight when player enters an area near NPC
    public void SawPlayer(){
        //animator.Play("Wave");
        //set animator parameter and audio (not necessary)
        if(currentAnim == "sad"){
            animator.Play("wave");
        }else{
            animator.Play("salute");
        }
        if (waveAudio!=null) waveAudio.Play();
    }

    //IInteractable implementation
    public void OnInteract(Interactor newInteractor)
    {
        onInteract = true; //flag to true
        interactor = newInteractor; //store interactor for later
        dialogueIndex = 0; //reset
        if (interactAudio!=null) interactAudio.Play();
       
        if (currentAnim != "warrior" && currentAnim != "floor"){
            animator.SetBool("talking",true);
             if(currentAnim != "idle" ){
                animator.SetBool(currentAnim, false);
             }
        }

        if (beggarHint){
            dialogues = dialogueHint;
            //dialogues = new string[6]{"Toss a coin to your witcher oh valley of plenty", "Ehm excuse me", "I meant spare a coin weary traveller", "Thank you", "I heard you are looking for a key", "Look behind a house"};
        }
        if (questGiven){
            dialogues = dialogueQuest;
           // dialogues = new string[]{"Did you find it?", "Ohh no problem", "Take your time. I will wait here in the cold"};
        }
        if (foundKey){
            dialogues = dialogueKey;
           // dialogues = new string[]{"Good job Traveller", "I will unlock the door for you", "There is a chest inside. It is all yours"};
        }
        
       if (interactAudio!=null) interactAudio.Play(); //play audio if exists
      // animator.SetTrigger("Interacting"); //set animator parameter

        GiveNextDialogue(); //give next dialogue, basically first dialogue
    }

    //send interactor next string to diplay
    void GiveNextDialogue(){
        //if dialogue index have reaches max dialogues
        //index + 1 (for next dialogue) greater than the amount of dialogue strings
        if (dialogueIndex+1 > dialogues.Length){
            if ( currentAnim != "floor") {if (foundKey == false) {questGiven = true;} else {questGiven = false;}}
            OnEndDialogue();
            return;
        }

        interactor.ReceiveInteract(dialogues[dialogueIndex]);
        dialogueIndex++; //ready for next dialogue
    }

    //request interactor to end interact, Call event and reset variables
    void OnEndDialogue(){
        interactor.EndInteract(gameObject); //request interactor to end Interact

        if (foundKey){
            key.Invoke();
        }
        if (questGiven){
            quest.Invoke();
        }


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
        //search for button names on Edit/Project Settings/Input Manager
        if (onInteract && Keyboard.current.enterKey.wasPressedThisFrame && interactor!=null){
            GiveNextDialogue();
        }
    }
}
