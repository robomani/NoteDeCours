using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int m_CurrentRoomIndex;
    public int m_PlayerXP;

    public Vector3 m_PlayerPos;
    public int m_PlayerHP;

    public List<Vector3> m_EnemyPos;
    public List<int> m_EnemyHP;
}
