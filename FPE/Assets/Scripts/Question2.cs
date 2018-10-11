using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question2 : MonoBehaviour
{
    private Transform m_Child = null;

    private void OnCollisionEnter(Collision i_Collision)
    {
        if (i_Collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

        }
        else
        {
            if (m_Child == null)
            {
                m_Child = i_Collision.gameObject.transform;
            }         
        }
    }

    private void OnCollisionExit(Collision i_Collision)
    {
        if (i_Collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

        }
        else
        {
            if (m_Child.gameObject == i_Collision.gameObject)
            {
                m_Child = null;
            }
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && m_Child != null)
        {
            m_Child.parent = transform;
        }

        if (Input.GetButtonUp("Fire1") && m_Child != null)
        {
            m_Child.parent = null;
        }
    }


}
