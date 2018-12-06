using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public RectTransform m_CommandsRoot;
    public Command m_CommandPrefab;

    public void AddCommand(string i_Lablel, Action i_Callback)
    {
        Command btn = Instantiate(m_CommandPrefab, m_CommandsRoot);
        btn.Label = i_Lablel;
        btn.Callback = i_Callback;
    }
}
