using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question4 : MonoBehaviour {

    private void OnCollisionEnter(Collision i_Collision)
    {
        if (i_Collision.gameObject.layer == LayerMask.NameToLayer("Spheres") && !i_Collision.gameObject.GetComponent<Question1>())
        {
            i_Collision.gameObject.AddComponent<Question1>();
        }
    }
}
