using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatusUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_HeroNameTxt;
    [SerializeField] TextMeshProUGUI m_HealthPointTxt;
    [SerializeField] TextMeshProUGUI m_MagicPointTxt;
    [SerializeField] Slider m_ProgressBarSlider;
    [SerializeField] Slider m_HP_Slider;
    [SerializeField] Slider m_MP_Slider;

    public string HeroName
    {
        get { return m_HeroNameTxt.text; }
        set { m_HeroNameTxt.text = value; }
    }

    int m_CurrentHP = 0;
    int m_MaxHP = 0;
    int m_CurrentMP = 0;
    int m_MaxMP = 0;

    bool m_Invalidated = false;

    public int CurrentHealthPoint
    {
        get { return m_CurrentHP; }
        set
        {
            m_CurrentHP = value;
            m_Invalidated = true;
        }
    }

    public int MaxHealthPoint
    {
        get { return m_MaxHP; }
        set
        {
            m_MaxHP = value;
            m_Invalidated = true;
        }
    }

    public int CurrentMagicPoint
    {
        get { return m_CurrentMP; }
        set
        {
            m_CurrentMP = value;
            m_Invalidated = true;
        }
    }

    public int MaxMagicPoint
    {
        get { return m_MaxMP; }
        set
        {
            m_MaxMP = value;
            m_Invalidated = true;
        }
    }

    public float ProgressBar
    {
        get { return m_ProgressBarSlider.value; }
        set { m_ProgressBarSlider.value = Mathf.Clamp(value, 0.0f, 1.0f); }
    }

    public void UpdateValues(Fighter fighter)
    {
        HeroName = fighter.name;

        CurrentHealthPoint = fighter.CurrentHP;
        CurrentMagicPoint = fighter.CurrentMP;

        if (fighter.State == FighterState.DEAD)
            ProgressBar = 0;
        else
            ProgressBar = fighter.m_ProgressBar/ fighter.m_Cooldown;

        MaxHealthPoint = fighter.MaxHP;
        MaxMagicPoint = fighter.MaxMP;
    }   

    private void Update()
    {
        if (m_Invalidated)
        {
            m_Invalidated = false;
            m_HealthPointTxt.text = $"HP: {m_CurrentHP}/{m_MaxHP}";
            m_MagicPointTxt.text = $"MP: {m_CurrentMP}/{m_MaxMP}";

            m_HP_Slider.value = m_CurrentHP / (float)m_MaxHP;
            m_MP_Slider.value = m_CurrentMP / (float)m_MaxMP;
        }
    }
}
