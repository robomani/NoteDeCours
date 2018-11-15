using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour {

    private void OnTriggerEnter(Collider i_Other)
    {
        if (i_Other.GetComponent<PlayerController>())
        {
            i_Other.GetComponent<PlayerController>().InWind();
        }
    }

    private void OnTriggerExit(Collider i_Other)
    {
        i_Other.GetComponent<PlayerController>().ExitWind();
    }
}
