using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommandButton : Button
{
    [SerializeField] TextMeshProUGUI m_NameTxt;

    public string Name
    {
        get { return m_NameTxt.text; }
        set { m_NameTxt.text = value; }
    }
}
