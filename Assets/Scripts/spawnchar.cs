using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnchar : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform MC;

    void Awake()
    {
        MC.position = spawnPoint.position;
    }
}
