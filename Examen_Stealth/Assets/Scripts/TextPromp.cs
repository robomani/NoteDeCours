using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromp : MonoBehaviour
{
    public GameObject m_InteractPromp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "InvisiblePlayer")
        {
            m_InteractPromp.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "InvisiblePlayer")
        {
            m_InteractPromp.SetActive(false);
        }
    }

}
