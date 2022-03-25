using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class drunkAi : MonoBehaviour
{ 
    private NavMeshAgent navMeshAgent;
    Animator animator;
    public UnityEvent trip;
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
