using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private Dictionary<EventID, Action<object>> m_EventDict;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        m_EventDict = new Dictionary<EventID, Action<object>>();
    }

    public void RegisterEvent(EventID i_ID, Action<object> i_Callback)
    {
        if (m_EventDict.ContainsKey(i_ID))
        {
            m_EventDict[i_ID] += i_Callback;
        }
        else
        {
            m_EventDict.Add(i_ID, i_Callback);
        }
    }

    public void UnregisterEvent(EventID i_ID, Action<object> i_Callback)
    {
        if (m_EventDict.ContainsKey(i_ID))
        {
            m_EventDict[i_ID] -= i_Callback;
        }
        else
        {
            Debug.LogError("The event you are unregistering dosent exist");
        }
    }

    public void DispatchEvent(EventID i_ID, object i_Param = null)
    {
        if (m_EventDict.ContainsKey(i_ID))
        {
            m_EventDict[i_ID](i_Param);
        }
        else
        {
            Debug.LogError("The event you are dispatching dosent exist");
        }
    }
}
