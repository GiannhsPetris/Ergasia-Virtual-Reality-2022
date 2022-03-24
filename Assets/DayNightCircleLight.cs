using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayNightCircleLight : MonoBehaviour
{
    [SerializeField] float dayIntensity = 0, nightIntensity = 1; 
    Light lightTarget;

    void Start()
    {
        //Get Light
        lightTarget = GetComponent<Light>();
        if (lightTarget == null) return;

        //subscribe to day and night events
        DayNightCircleManager.Instance.onDayTimeStart += OnDay;
        DayNightCircleManager.Instance.onNightTimeStart += OnNight;
    }

    void OnDay(){
        lightTarget.intensity = dayIntensity;
    }

    void OnNight(){
        lightTarget.intensity = nightIntensity;
    }

    void OnDestroy(){
        //UNsubscribe to day and night events when GameObject gets destroyed
        DayNightCircleManager.Instance.onDayTimeStart -= OnDay;
        DayNightCircleManager.Instance.onNightTimeStart -= OnNight;
    }
}
