using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class npc_animations : MonoBehaviour
{

    public string state;
 
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
