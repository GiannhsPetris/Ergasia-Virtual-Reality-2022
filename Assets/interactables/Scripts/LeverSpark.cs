using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: apostolos SOVOLOS
//Version: 1.0

public class LeverSpark : Lever
{
    [Header("Spark Variant")]
    [SerializeField] private GameObject spark;
    public override void OnInteract(Interactor interactor){
        base.OnInteract(interactor);
        print("override");
        if (!isJammed && isOn){
            print("spark");
            GameObject clone = GameObject.Instantiate(spark, transform);
            clone.SetActive(true);
            Destroy(clone, 1f);
        }
    }
}
