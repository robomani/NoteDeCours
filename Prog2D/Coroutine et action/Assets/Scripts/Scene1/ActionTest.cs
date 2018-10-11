using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTest : MonoBehaviour
{
    public Action m_Action;

    private void Update()
    {   
        if (m_Action != null)
        {
            m_Action();
        }
    }


}
