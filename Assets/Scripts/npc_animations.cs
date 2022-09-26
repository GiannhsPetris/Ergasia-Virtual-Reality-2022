using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class npc_animations : MonoBehaviour
{

    public string state;
 
    [SerializeField] private Animator animator;

    void Start()
    {
        switch (state) 
        {
        case "bartending":
            animator.SetBool("bartending", true);
            break;
        case "drinking":
            animator.SetBool("drinking", true);
            break;
        case "sitting":
            animator.SetBool("sitting", true);
            break;
        case "sitting2":
            animator.SetBool("sitting2", true);
            break;
        case "drunk":
            animator.SetBool("drunk", true);
            break;
        case "warrior":
            animator.SetBool("warrior", true);
            break;
        case "sad":
            animator.SetBool("sad", true);
            break;
        case "praying":
            animator.SetBool("praying", true);
            break;
        case "floor":
            animator.SetBool("floor", true);
            break;
        case "walkingM":
            animator.SetBool("walkingM", true);
            break;
        case "walkingF":
            animator.SetBool("walkingF", true);
            break;
        }
    }

    public void SetBoolTrue(string name) => animator.SetBool(name, true);
 
    public void SetBoolFalse(string name) => animator.SetBool(name, false);
 
}
