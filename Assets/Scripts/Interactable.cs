using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interactor calls and receives from an IInteractable
//anything we want to be interactable has to implement IInteractable
public interface IInteractable
{

    //abstract OnInteeract. It gets an Interactor so that it may return to it
    void OnInteract(Interactor interactor);
    string GetTxt();
}
