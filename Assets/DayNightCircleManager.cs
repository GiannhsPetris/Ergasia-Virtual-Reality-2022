using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCircleManager : MonoBehaviour
{
    public static DayNightCircleManager Instance; 

    void Awake()
    {
        //Make singleton unique 
        if (Instance != null && Instance != this) 
            Destroy(this);
        else Instance = this;
    }

    public event Action onDayTimeStart;
    public event Action onNightTimeStart;
    public event Action onBellRing;
    public event Action onBellStop;



    public void OnDayTimeStart(){
        if (onDayTimeStart != null){
            onDayTimeStart(); //call event
        }
    } 

    public void OnNightTimeStart(){
        if (onNightTimeStart != null){
            onNightTimeStart(); //call event
        }
    }

    public void OnBellRing(){
        if (onBellRing != null){
            onBellRing();
        }
    }

    public void OnBellStop(){
        if (onBellStop != null){
            onBellStop();
        }
    }
}
