using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Assets.SimpleLocalization;

//Author: apostolos SOVOLOS
//Version: 1.0

public class InteractTriggerEvent : MonoBehaviour, IInteractable
{
    public UnityEvent onInteract; //unity event can be really useful on Inspector
    public string hintText;
    
    //On interact, invoke event
    public void OnInteract(Interactor interactor)
    {
        onInteract.Invoke();
    }

     public string GetTxt(){
        if(hintText!=null){
            string temp = LocalizationManager.Localize(hintText);
            return temp;
        }
        return "error";
    }
}
