using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Assets.SimpleLocalization;

public class BeerInteract : MonoBehaviour, IInteractable
{
    //------Setup in Inspector---------------------
    public Animator animator;
    [TextArea(3,10)]
    public string[] dialogues; //array of string of NPC dialogues
    public UnityEvent onEndDialogue; //unity event can be really useful on Inspector
    public UnityEvent onStart;
    public GameObject cam, character;
    //----------------------------------------------
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




    //IInteractable implementation
    public void OnInteract(Interactor newInteractor)
    {
        onInteract = true; //flag to true
        interactor = newInteractor; //store interactor for later
        dialogueIndex = 0; //reset

        onStart.Invoke();
        character.GetComponent<CharacterController>().enabled = false;
        character.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        character.GetComponent<PlayerInput>().enabled = false;
        character.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = false;
        cam.SetActive(true);
        animator.Play("drinking");


        GiveNextDialogue(); //give next dialogue, basically first dialogue
    }

    //send interactor next string to diplay
    void GiveNextDialogue(){
        //if dialogue index have reaches max dialogues
        //index + 1 (for next dialogue) greater than the amount of dialogue strings
        if (dialogueIndex+1 > dialogues.Length){
            //character.GetComponent<CharacterController>().enabled = false;
            //character.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
            character.GetComponent<PlayerInput>().enabled = false;
            //character.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = false;
            cam.SetActive(true);
            animator.Play("drinking");
            return;
        }

        string tempDial = LocalizationManager.Localize(dialogues[dialogueIndex]);

        interactor.ReceiveInteract(tempDial);
        dialogueIndex++; //ready for next dialogue
    }

    //request interactor to end interact, Call event and reset variables
    public void OnEndDialogue(){
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
        character.GetComponent<CharacterController>().enabled = true;
        character.GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
        character.GetComponent<PlayerInput>().enabled = true;
        character.GetComponent<StarterAssets.StarterAssetsInputs>().enabled = true;
        cam.SetActive(false);
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

