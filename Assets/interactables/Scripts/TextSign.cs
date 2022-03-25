using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class of a sign, it contains a message for display
public class TextSign : MonoBehaviour, IInteractable
{
    [TextArea(3,10)]
    public string text, hintText;
    public void OnInteract(Interactor interactor){
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        interactor.ReceiveInteract(text);
    }

     public string GetTxt(){
        if(hintText!=null){
            return hintText;
        }
        return "error";
    }
}
