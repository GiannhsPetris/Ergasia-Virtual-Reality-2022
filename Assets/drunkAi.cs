using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class drunkAi : MonoBehaviour
{ 
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform movePoint;
    private void Awake(){
       navMeshAgent = GetComponent<NavMeshAgent>();
    }



    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePoint.position;
    }
}
