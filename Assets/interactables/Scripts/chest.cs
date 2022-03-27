using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: apostolos SOVOLOS
//Version: 1.0

public class chest : MonoBehaviour , IInteractable
{
    [SerializeField] bool isOpen, isLocked;
    [TextArea(2,10)]
    [SerializeField] string lockedText;
    [SerializeField] Animator animator;

    public string hintText;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Open", isOpen);
    }

    public void OnInteract(Interactor interactor){
        if (isLocked){
            interactor.ReceiveInteract(lockedText);
        }
        else {
            isOpen = !isOpen;
            animator.SetBool("Open", isOpen);
        }
    }

    public void Lock(){
        isLocked = true;
        isOpen = false;
        animator.SetBool("Open", false);
    }

    public void Unlock(){
        isLocked = false;
    }

     public string GetTxt(){
        if(hintText!=null){
            return hintText;
        }
        return "error";
    }
}
