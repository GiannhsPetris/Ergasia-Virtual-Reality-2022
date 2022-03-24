using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class drunkAi : MonoBehaviour
{ 
    private NavMeshAgent navMeshAgent;
    Animator animator;
    [SerializeField] private Transform movePoint;
    private void Start(){
       navMeshAgent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();
       animator.SetBool("drunk walk", true);
        navMeshAgent.destination = movePoint.position;
    }



    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete 
        if (navMeshAgent.remainingDistance <= 0.5f){
            animator.SetBool("trip", true);
           // navMeshAgent.enabled = false;
        }
    }
}
