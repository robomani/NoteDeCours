using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int m_CurrentHP;
    public int m_MaxHP;

    private void Awake()
    {
        m_CurrentHP = m_MaxHP;
    }

    private void Start()
    {
        EventManager.Instance.RegisterEvent(EventID.SaveGame, OnSaveGame);
        EventManager.Instance.RegisterEvent(EventID.LoadeGame, OnLoadGame);
    }

    private void OnLoadGame(object i_Arg)
    {
        m_CurrentHP = SaveManager.Instance.CurrentGameData.m_PlayerHP;
        UpdateHP();
    }

    private void OnSaveGame(object i_Arg)
    {
        SaveManager.Instance.CurrentGameData.m_PlayerHP = m_CurrentHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_CurrentHP -= 10;
            UpdateHP();
        }
    }

    private void UpdateHP()
    {
        float hpPercent = 0;
        if (m_MaxHP != 0)
        {
            hpPercent = m_CurrentHP / (float)m_MaxHP;
        }
        EventManager.Instance.DispatchEvent(EventID.UpdateHP, hpPercent);
    }
}
