using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;


//A class of a sign, it contains a message for display
public class TextSign : MonoBehaviour, IInteractable
{
    [TextArea(3,10)]
    public string text, hintText;
    public void OnInteract(Interactor interactor){
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        string temp = LocalizationManager.Localize(text);
        interactor.ReceiveInteract(temp);
    }

     public string GetTxt(){
        if(hintText!=null){
            string temp = LocalizationManager.Localize(hintText);
            return temp;
        }
        return "error";
    }

    public void Start(){
        LocalizationManager.Language = GameManager.lang;

    }
}
