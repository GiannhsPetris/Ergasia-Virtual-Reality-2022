using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: apostolos SOVOLOS
//Version: 1.0

public class DoorAutomatic : MonoBehaviour
{
    [SerializeField] bool isLocked;
    [SerializeField] Animator animator;

    void Start(){
        if (isLocked) Lock();
        else Unlock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")){
            animator.SetBool("Open", false);
        }
    }

    public void Lock(){
        isLocked = true;
        animator.SetBool("Open", true);
    }

    public void Unlock(){
        isLocked = false;
    }
}
