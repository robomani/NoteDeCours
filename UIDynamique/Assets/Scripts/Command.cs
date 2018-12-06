using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text m_Label;

    [SerializeField]
    private UnityEngine.UI.Button m_Button;

    public string Label
    {
        get
        {
            return m_Label.text;
        }
        set
        {
            m_Label.text = value;
        }
    }

    private Action m_Callback;
    public Action Callback
    {
        get
        {
            return m_Callback;
        }
        set
        {
            if (value != m_Callback)
            {
                m_Callback = value;
                if (m_Callback != null)
                {
                    m_Button.onClick.RemoveAllListeners();
                    
                    if (m_Callback != null)
                    {
                        m_Button.onClick.AddListener(() => m_Callback()); //Lambda appelle action pour creer un unity action qui fait juste notre action
                    }
                }
            }
        }
    }
}
