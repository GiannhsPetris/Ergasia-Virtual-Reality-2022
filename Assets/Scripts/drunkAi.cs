using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class drunkAi : MonoBehaviour
{ 
    Animator animator;
    private NavMeshAgent navMeshAgent;
    public UnityEvent trip;
    [SerializeField] private Transform movePoint;


    private void Start(){
       navMeshAgent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();
       animator.SetBool("drunk walk", true);
        navMeshAgent.destination = movePoint.position;
    }



    void Update()
    {
        if (navMeshAgent.enabled == true){
            if (navMeshAgent.remainingDistance <= 0.5f){
                animator.SetBool("trip", true);
                navMeshAgent.enabled = false;
                GetComponent<Collider>().enabled = false;
                trip.Invoke();
            }
        }
      
    }
}
