using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonSetup : MonoBehaviour
{
    public Vector3 newLocalPosition = new Vector3(0f,0f,1000f);
    public Vector3 newLocalScale = new Vector3(15f,15f,15f);
    
    void Start()
    {
        transform.localPosition = newLocalPosition;
        transform.localScale = newLocalScale;
    }
}
