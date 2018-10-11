using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject m_Obstacle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Obstacle.SetActive(!m_Obstacle.activeInHierarchy);
        }
    }
}
