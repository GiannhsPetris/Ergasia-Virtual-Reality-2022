using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform[] points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    float timer;
    public float waitingTime = 5f;
    public string walking;

    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        timer = 0;
        agent.autoBraking = false;
        animator.SetBool(walking, true);

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance <= 0.5f){
            animator.SetBool("stop", true);
            animator.SetBool(walking, false);
            agent.destination = transform.position;
            timer += Time.deltaTime;
            if (timer >= waitingTime){
                timer = 0;
                animator.SetBool(walking, true);
                animator.SetBool("stop", false);
                GotoNextPoint();
            }
        }
    }
}
