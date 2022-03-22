using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class npc_animations : MonoBehaviour
{

    public string state;
    public int test;
    Animator animator;

    void Awake(){
       
    }

    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();

        switch (state) 
        {
        case "bartending":
            animator.SetBool("bartending", true);
            test = 1;
            break;
        case "drinking":
            animator.SetBool("drinking", true);
            test = 2;
            break;
        case "sitting":
            animator.SetBool("sitting", true);
            test = 3;
            break;
        case "sitting2":
            animator.SetBool("sitting2", true);
            test = 4;
            break;
        case "drunk":
            animator.SetBool("drunk", true);
            test = 5;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
