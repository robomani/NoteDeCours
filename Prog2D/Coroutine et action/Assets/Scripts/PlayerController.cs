using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int m_HP = 10;

    //public Action<int> m_HurtAction;

    private void Start()
    {
        GameManager.Instance.m_Player = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage();
        }
    }



    private void Damage()
    {
        m_HP--;
        EventManager.Instance.DispatchEvent(EventID.UpdateHP, m_HP);
        /*
        if (m_HurtAction != null)
        {
            m_HurtAction(m_HP);
        }
        */
    }

    private void OnDestroy()
    {
        GameManager.Instance.m_Player = null;
    }
}
