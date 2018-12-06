using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] Image m_IconImg;
    [SerializeField] TextMeshProUGUI m_NameTxt;
    [SerializeField] TextMeshProUGUI m_MagicPointTxt;

    public Sprite Icon
    {
        get { return m_IconImg.sprite; }
        set { m_IconImg.sprite = value; }
    }

    public string Name
    {
        get { return m_NameTxt.text; }
        set { m_NameTxt.text = value; }
    }

    int mp = 0;
    public int MP
    {
        get { return mp;}
        set
        {
            mp = value;
            m_MagicPointTxt.text = mp > 0 ? $"{mp} MP" : "";
        }
    }
}
