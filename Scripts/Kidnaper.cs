using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kidnaper : MonoBehaviour
{
    private Collision m_Collision;


    private void Update ()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {

            m_Collision.transform.parent = null;
        }
        

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Box" && Input.GetKey(KeyCode.E))
        {
            collision.transform.parent = transform;
            m_Collision = collision;
        }
    }

}
