using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{

    private void OnTriggerEnter(Collider i_Other)
    {
        if (i_Other.GetComponent<PlayerController>())
        {
            i_Other.GetComponent<PlayerController>().InWater();
        }
    }

    private void OnTriggerExit(Collider i_Other)
    {
        i_Other.GetComponent<PlayerController>().ExitWater();
    }
}
