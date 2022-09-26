using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//version 1.0
public class HumanNPCSight : MonoBehaviour
{
    private HumanNPC humanNPC;

    // Start is called before the first frame update
    void Start()
    {
        humanNPC = GetComponentInParent<HumanNPC>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && humanNPC!=null){
            humanNPC.SawPlayer();
        }
    }
}
