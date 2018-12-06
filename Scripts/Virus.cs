using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {

            collision.gameObject.AddComponent <PlayerController>();
            collision.gameObject.AddComponent <Virus>();
        }
    }
}
