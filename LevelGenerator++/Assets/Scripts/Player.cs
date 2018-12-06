using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData m_Data;

    private float m_CurrentHp;
    private float m_CurrentSpeed;

	// Use this for initialization
	void Start ()
    {
        m_CurrentHp = m_Data.HP;
        m_CurrentSpeed = m_Data.Speed;
    }
}
