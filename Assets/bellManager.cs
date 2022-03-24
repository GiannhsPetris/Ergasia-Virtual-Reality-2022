using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellManager : MonoBehaviour
{

    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        DayNightCircleManager.Instance.onBellRing += OnRing;
        DayNightCircleManager.Instance.onBellStop += OnStop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRing(){
        animator.Play("bell");
        audioSource.Play();
    }

    void OnStop(){
        animator.Play("bellidle");
        audioSource.Stop();
    }
}
