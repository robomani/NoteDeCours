using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision i_Collision)
    {
        i_Collision.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
