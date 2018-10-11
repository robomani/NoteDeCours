using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Slider m_LifeBar;

    private void Start()
    {
        /*
        if (GameManager.Instance.m_Player != null)
        {
            //GameManager.Instance.m_Player.m_HurtAction += SetLifeValue;
            
        } 
        */
        EventManager.Instance.RegisterEvent(EventID.UpdateHP, SetLifeValue);
    }

    private void SetLifeValue(object a_Value)
    {
        m_LifeBar.value = (int)a_Value;
    }
    /*
    private void SetLifeValue(int a_Value)
    {
        m_LifeBar.value = a_Value;
    }
    */
    private void OnDestroy()
    {
        /*
        if (GameManager.Instance.m_Player != null)
        {
            //GameManager.Instance.m_Player.m_HurtAction -= SetLifeValue;
            
        }
        */
        EventManager.Instance.UnregisterEvent(EventID.UpdateHP, SetLifeValue);
    }
}
